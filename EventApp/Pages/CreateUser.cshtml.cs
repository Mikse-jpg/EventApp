using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using EventAppLib.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages
{
    public class CreateUserModel : PageModel
    {
        private IService<User> _user;

        [BindProperty]
        public User User { get; set; }

        public CreateUserModel(IService<User> user)
        {
            _user = user;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            

            return RedirectToPage("/Index");
        }
    }
}
