using Microsoft.EntityFrameworkCore;
using MyLibrary.Core.Domain;
using MyLibrary.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(Book x)
        {
            try
            {
                _appDbContext.Book.Add(x);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Book>> BrowseAll()
        {
            return await Task.FromResult(_appDbContext.Book.Include("BookAuthors"));
        }

        public async Task Delete(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Book.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Book> Get(int id)
        {
            return await Task.FromResult(_appDbContext.Book.FirstOrDefault(x => x.Id == id));
        }

        public async Task Update(Book x)
        {
            try
            {
                var toUpdate = _appDbContext.Book.FirstOrDefault(b => b.Id == x.Id);

                toUpdate.Title = x.Title;
                toUpdate.ImageURL = x.ImageURL;
                toUpdate.BookAuthors = x.BookAuthors;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
