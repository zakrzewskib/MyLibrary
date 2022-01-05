using MyLibrary.Core.Domain;
using MyLibrary.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private AppDbContext _appDbContext;
        public BookAuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(BookAuthor x)
        {
            try
            {
                _appDbContext.BookAuthor.Add(x);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<BookAuthor>> BrowseAll()
        {
            return await Task.FromResult(_appDbContext.BookAuthor);
        }

        public async Task Delete(int bookId)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.BookAuthor.FirstOrDefault(x => x.BookId == bookId));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<BookAuthor>> Get(int bookId)
        {
            return await Task.FromResult(_appDbContext.BookAuthor.Where(x => x.BookId == bookId));
        }
    }
}
