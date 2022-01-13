using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyLibrary.Core.Repositories;
using MyLibrary.Infrastructure.Repositories;
using MyLibrary.WebAPI;
using MyLibrary.WebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.Controllers
{
    [EnableCors]
    public class BookController : Controller
    {
        private IAuthorRepository _authorRepository;

        public IConfiguration Configuration;

        JWToken JWToken;

        public BookController(IConfiguration configuration, IAuthorRepository authorRepository)
        {
            Configuration = configuration;
            _authorRepository = authorRepository;
            JWToken = new JWToken(configuration);
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

        [Authorize(Roles = "admin")]
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

            //string _restpath = GetHostUrl().Content + ControllerName();

            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync($"{_restpath}"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //    }
            //}
            //return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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

        public async Task<IActionResult> Edit(int id)
        {
           
            string _restpath = GetHostUrl().Content + ControllerName();
            BookEditVM bookVM = new BookEditVM();

           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    bookVM = JsonConvert.DeserializeObject<BookEditVM>(apiResponse);
                }
            }

            var authorsFromRepo = await _authorRepository.BrowseAll();
            var selectList = new List<SelectListItem>();
            List<String> authors = new List<String>();

            foreach (var item in authorsFromRepo)
            {
                selectList.Add(new SelectListItem(item.Name + " " + item.Surname, item.Id.ToString()));
                foreach (var author in bookVM.Authors)
                {
                    if(item.Id == author.Id)
                    {
                        selectList.FirstOrDefault(x => x.Value == item.Id.ToString()).Selected = true;
                    }
                }
            }

            bookVM.AuthorsSelectList = selectList;

            return View(bookVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditVM book)
        {
            try
            {
                var tokenString = JWToken.TokenString;


                foreach (var item in book.SelectedAuthors)
                {
                    var author = await _authorRepository.Get(Int32.Parse(item));
                    book.Authors.Add(author);
                }

                string _restpath = GetHostUrl().Content + ControllerName();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenString);

                    string jsonString = System.Text.Json.JsonSerializer.Serialize(book);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{book.Id}", content))
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            return RedirectToAction("Index", "Home");
                        }

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

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            BookVM b = new BookVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<BookVM>(apiResponse);
                }
            }
            return View(b);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookVM b)
        {
            try
            {
                string _restpath = GetHostUrl().Content + ControllerName();

                BookVM book = new BookVM();

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(b);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{b.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<BookVM>(apiResponse);
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
