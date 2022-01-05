using MyLibrary.Core.Domain;
using MyLibrary.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Commands
{
    public class CreateBook
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
