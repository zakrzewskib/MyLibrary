using MyLibrary.Core.Domain;
using MyLibrary.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext _appDbContext;

        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Add(Author x)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Author>> BrowseAll()
        {
            return await Task.FromResult(_appDbContext.Author);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> Get(int id)
        {
            return await Task.FromResult(_appDbContext.Author.FirstOrDefault(x => x.Id == id));
        }

        public Task Update(Author x)
        {
            throw new NotImplementedException();
        }
    }
}
