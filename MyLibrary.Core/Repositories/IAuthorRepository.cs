using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Repositories
{
    public interface IAuthorRepository
    {
        Task Add(Author x);
        Task Update(Author x);
        Task Delete(int id);
        Task<Author> Get(int id);
        Task<IEnumerable<Author>> BrowseAll();
    }
}
