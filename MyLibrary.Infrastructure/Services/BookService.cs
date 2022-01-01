using MyLibrary.Core.Domain;
using MyLibrary.Core.Repositories;
using MyLibrary.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookAuthorRepository bookAuthorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }
        public async Task Add(BookDTO x)
        {
            //Book book = new Book()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    ImageURL = x.ImageURL,
            //    BookAuthors = x.BookAuthors
            //};
            //await _bookRepository.Add(book);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDTO>> BrowseAll()
        {
            throw new NotImplementedException();
            //var books = await _bookRepository.BrowseAll();

            //foreach (var item in books)
            //{
            //    foreach (var bookauthor in item.BookAuthors)
            //    {

            //    }
            //}

            //return books.Select(x => new BookDTO()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    ImageURL = x.ImageURL,
            //});
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDTO> Get(int id)
        {
            var x = await _bookRepository.Get(id);
            var s = await _bookAuthorRepository.BrowseAll();
           
            List<AuthorDTO> bookAuthors = new List<AuthorDTO>();
            foreach (var item in s)
            {
                if (item.BookId == id)
                {
                    var author = await _authorRepository.Get(item.AuthorId);
                    bookAuthors.Add(new AuthorDTO()
                    {
                        Id = author.Id,
                        Name = author.Name,
                        Surname = author.Surname
                    });
                }

            };

            return new BookDTO()
            {
                Id = x.Id,
                Title = x.Title,
                ImageURL = x.ImageURL,
                Authors = bookAuthors
            };
        }

        public Task Update(BookDTO X, int id)
        {
            throw new NotImplementedException();
        }
    }
}
