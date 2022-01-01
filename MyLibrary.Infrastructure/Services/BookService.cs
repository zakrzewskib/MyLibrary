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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDTO>> BrowseAll()
        {
            var x = await _bookRepository.BrowseAll();
            List<BookDTO> result = new List<BookDTO>();

            var bookAuthors = await _bookAuthorRepository.BrowseAll();

            foreach (var book in x)
            {
                List<AuthorDTO> authors = new List<AuthorDTO>();
                foreach (var item in bookAuthors)
                {
                    if (item.BookId == book.Id)
                    {
                        var author = await _authorRepository.Get(item.AuthorId);

                        authors.Add(new AuthorDTO()
                        {
                            Id = author.Id,
                            Name = author.Name,
                            Surname = author.Surname
                        });
                    }
                }
                result.Add(new BookDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    ImageURL = book.ImageURL,
                    Authors = authors
                });
               
            };
            return result;

        }

        //private async Task<List<AuthorDTO>> GetAuthorsOfBookAsync(int id)
        //{
        //    var bookAuthors = await _bookAuthorRepository.BrowseAll();

        //    List<AuthorDTO> authors = new List<AuthorDTO>();
        //    foreach (var item in bookAuthors)
        //    {
        //        if (item.BookId == id)
        //        {
        //            var author = await _authorRepository.Get(item.AuthorId);

        //            authors.Add(new AuthorDTO()
        //            {
        //                Id = author.Id,
        //                Name = author.Name,
        //                Surname = author.Surname
        //            });
        //        }
        //    };
        //    return authors;
        //}

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDTO> Get(int id)
        {
            var x = await _bookRepository.Get(id);
            var bookAuthors = await _bookAuthorRepository.BrowseAll();
           
            List<AuthorDTO> authors = new List<AuthorDTO>();
            foreach (var item in bookAuthors)
            {
                if (item.BookId == id)
                {
                    var author = await _authorRepository.Get(item.AuthorId);

                    authors.Add(new AuthorDTO()
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
                Authors = authors
            };
        }

        public Task Update(BookDTO X, int id)
        {
            throw new NotImplementedException();
        }
    }
}
