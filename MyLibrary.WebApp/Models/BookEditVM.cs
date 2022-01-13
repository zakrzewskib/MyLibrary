using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.Models
{
    public class BookEditVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public string[] SelectedAuthors { get; set; }
        public List<SelectListItem> AuthorsSelectList { get; set; }
    }
}
