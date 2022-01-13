using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Infrastructure.Commands;
using MyLibrary.Infrastructure.DTO;
using MyLibrary.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.WebAPI.Controllers
{
    [Route("[Controller]")]
    [EnableCors]
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
        public async Task<IActionResult> Get(int id)
        {
            BookDTO x = await _bookService.Get(id);
            return Json(x);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            BookDTO x = await _bookService.Get(id);
            await _bookService.Delete(id);
            return Json(x);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBook createBook)
        {
            BookDTO book = new BookDTO()
            {
                Title = createBook.Title,
                ImageURL = createBook.ImageURL,
                Authors = createBook.Authors
            };
            
            await _bookService.Add(book);

            IEnumerable <BookDTO> books = await _bookService.BrowseAll();

            return Json(books);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBook updateBook, int id)
        {
            BookDTO book = new BookDTO()
            {
                Title = updateBook.Title,
                ImageURL = updateBook.ImageURL,
                Authors = updateBook.Authors
            };

            await _bookService.Update(book, id);

            BookDTO b = await _bookService.Get(id);
            return Json(b);
        }
    }
}
