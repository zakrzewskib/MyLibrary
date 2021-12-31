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
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task Add(BookDTO x)
        {
            Book book = new Book()
            {
                Id = x.Id,
                Title = x.Title,
                ImageURL = x.ImageURL,
                Authors = x.Authors,
                PublishingHouse = x.PublishingHouse,
                Accessibilities = x.Accessibilities
            };
            await _bookRepository.Add(book);
        }

        public async Task<IEnumerable<BookDTO>> BrowseAll()
        {
            var books = await _bookRepository.BrowseAll() ;

            return books.Select(x => new BookDTO()
            {
                Id = x.Id,
                Title = x.Title,
                ImageURL = x.ImageURL,
                Authors = x.Authors,
                PublishingHouse = x.PublishingHouse,
                Accessibilities = x.Accessibilities,
                Comments = x.Comments,
            });
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(BookDTO X, int id)
        {
            throw new NotImplementedException();
        }
    }
}
