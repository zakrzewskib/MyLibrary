using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password need to longer than {2}!", MinimumLength = 5)]
        public string Password { get; set; }
    }
}
