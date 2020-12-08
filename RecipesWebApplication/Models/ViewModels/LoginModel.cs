using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//for the attributes eg required etc
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]//hide password characters
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";//if there is no url, it will return tot he main page/ root 
    }
}
