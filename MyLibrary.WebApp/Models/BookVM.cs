using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.Models
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public ICollection<Accessibility> Accessibilities { get; set; }
    }
}
