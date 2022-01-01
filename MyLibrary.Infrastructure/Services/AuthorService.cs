using MyLibrary.Core.Repositories;
using MyLibrary.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task Add(AuthorDTO x)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorDTO> Get(int id)
        {
            var x = await _authorRepository.Get(id);

            return new AuthorDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            };
        }

        public Task Update(AuthorDTO x, int id)
        {
            throw new NotImplementedException();
        }
    }
}
