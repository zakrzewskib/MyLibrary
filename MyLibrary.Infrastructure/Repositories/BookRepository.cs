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
        public Task Add(Book x)
        {
            throw new NotImplementedException();
        }

        public Task BrowseAll(Book x)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book x)
        {
            throw new NotImplementedException();
        }
    }
}
