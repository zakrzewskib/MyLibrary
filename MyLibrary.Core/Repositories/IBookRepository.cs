using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Repositories
{
    public interface IBookRepository
    {
        Task Add(Book x);
        Task Update(Book x);
        Task Delete(int id);
        Task<Book> Get(int id);
        Task<IEnumerable<Book>> BrowseAll();
    }
}
