using MyLibrary.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Services
{
    public interface IBookService
    {
        Task Add(BookDTO x);
        Task Update(BookDTO x, int id);
        Task Delete (int id);
        Task<BookDTO> Get(int id);
        Task<IEnumerable<BookDTO>> BrowseAll();

    }
}
