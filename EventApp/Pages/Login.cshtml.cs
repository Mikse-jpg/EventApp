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
using System.Web;

namespace EventApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IService<User> _user;

        public string ErrorMessage;

        public LoginModel(IService<User> user)
        {
            _user = user;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost(User user)
        {
            var result = _user.Check(user);

            if (result)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                
                ErrorMessage = "You're not to be found in the system. Please try again.";
                return Page();
                
            }

            return Page();
        }


    }
}
