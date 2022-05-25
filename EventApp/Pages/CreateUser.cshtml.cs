using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using EventAppLib.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EventApp.Pages
{
    public class CreateUserModel : PageModel
    {
        private IService<User> _user;

        private readonly ILogger<IndexModel> _logger;
        private LoggedInUser _loggedInUser;

        public LoggedInUser loggedinuser { get => _loggedInUser; }

        [BindProperty]
        public User User { get; set; }

        public string ErrorMessage;

        public CreateUserModel(ILogger<IndexModel> logger, IService<User> user, LoggedInUser loggedInUser)
        {
            _user = user;
            _logger = logger;
            _loggedInUser = loggedInUser;
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

            loggedinuser.LoggedIn = true;
            _loggedInUser.Id = User.Id;
            _loggedInUser.Username = user.Username;
            _loggedInUser.Roletype = user.Roletype;

            _user.Create(User);
            return RedirectToPage("/Index");
        }
    }
}
