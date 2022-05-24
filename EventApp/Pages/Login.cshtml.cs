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
using Microsoft.Extensions.Logging;

namespace EventApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IService<User> _user;
        private readonly ILogger<IndexModel> _logger;
        private LoggedInUser _loggedInUser;

        public LoggedInUser loggedinuser { get => _loggedInUser; }

        public string ErrorMessage;

        [BindProperty]
        public User User { get; set; }


        public LoginModel(ILogger<IndexModel> logger, IService<User> user, LoggedInUser loggedInUser)
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
            var result = _user.Check(user);

            if (result)
            {
                loggedinuser.LoggedIn = true;
                _loggedInUser.Id = user.Id;
                _loggedInUser.Username = user.Username;
                _loggedInUser.Roletype = user.Roletype;

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
