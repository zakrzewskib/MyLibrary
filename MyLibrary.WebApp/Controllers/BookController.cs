using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyLibrary.Core.Repositories;
using MyLibrary.Infrastructure.Repositories;
using MyLibrary.WebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.Controllers
{
    public class BookController : Controller
    {
        private IAuthorRepository _authorRepository;

        public IConfiguration Configuration;
        public BookController(IConfiguration configuration, IAuthorRepository authorRepository)
        {
            Configuration = configuration;
            _authorRepository = authorRepository;
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
            //string _restpath = GetHostUrl().Content + ControllerName();

            //List<BookVM> books = new List<BookVM>();

            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync(_restpath))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        books = JsonConvert.DeserializeObject<List<BookVM>>(apiResponse);
            //    }
            //}

            //return View(books);
            return View();

        }

        public async Task<IActionResult> Create()
        {
            var authorsFromRepo = await _authorRepository.BrowseAll();
            var selectList = new List<SelectListItem>();

            foreach (var item in authorsFromRepo)
            {
                selectList.Add(new SelectListItem(item.Name + " " + item.Surname, item.Id.ToString()));
            }
            var vm = new BookCreateVM()
            {
                AuthorsSelectList = selectList
            };

            return View(vm);

            string _restpath = GetHostUrl().Content + ControllerName();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateVM book)
        {
            try
            {
                foreach (var item in book.SelectedAuthors)
                {
                    var author = await _authorRepository.Get(Int32.Parse(item));
                    book.Authors.Add(author);
                }

                string _restpath = GetHostUrl().Content + ControllerName();

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(book);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
