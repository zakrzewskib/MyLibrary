using Microsoft.AspNetCore.Mvc;
using MyLibrary.Infrastructure.DTO;
using MyLibrary.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<BookDTO> x = await _bookService.BrowseAll();
            return Json(x);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZawodnik(int id)
        {
            BookDTO x = await _bookService.Get(id);
            return Json(x);
        }


    }
}
