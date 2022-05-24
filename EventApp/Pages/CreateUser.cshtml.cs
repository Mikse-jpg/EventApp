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

        public string ErrorMessage;

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
                ErrorMessage = $"Cannot create user. Please try again. Check if Username & Password is below 8 signs.";
                return Page();
            }

            if (_user.GetAll().Count == 0)
            {
                User.Id = 0;

            }
            else
            {
                User.Id = _user.GetAll().Count + 1;
            }

            _user.Create(User);
            return RedirectToPage("/Index");
        }
    }
}
