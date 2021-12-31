using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyLibrary.WebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.Controllers
{
    public class BookController : Controller
    {
        public IConfiguration Configuration;
        public BookController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string ControllerName()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }

        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            List<BookVM> books = new List<BookVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<BookVM>>(apiResponse);
                }
            }

            return View(books);
        }

    }
}
