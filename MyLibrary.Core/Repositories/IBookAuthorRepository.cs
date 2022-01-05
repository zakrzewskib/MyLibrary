using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Repositories
{
    public interface IBookAuthorRepository
    {
        Task<IEnumerable<BookAuthor>> BrowseAll();
        Task Add(BookAuthor x);
    }
}
