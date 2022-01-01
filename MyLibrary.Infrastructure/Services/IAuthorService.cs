using MyLibrary.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Services
{
    public interface IAuthorService
    {
        Task Add(AuthorDTO x);
        Task Update(AuthorDTO x, int id);
        Task Delete(int id);
        Task<AuthorDTO> Get(int id);
        Task<IEnumerable<AuthorDTO>> BrowseAll();
    }
}
