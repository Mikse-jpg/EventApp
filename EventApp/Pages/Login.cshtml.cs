using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using EventAppLib.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EventApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IService<User> _user;

        public LoginModel(IService<User> user)
        {
            _user = user;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }



        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
