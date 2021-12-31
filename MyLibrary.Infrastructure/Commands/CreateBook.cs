using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Commands
{
    class CreateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public ICollection<Author> Authors { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public ICollection<Accessibility> Accessibilities { get; set; }
    }
}
