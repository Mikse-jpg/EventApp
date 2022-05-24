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
    public class ProfileModel : PageModel
    {
        private User _user;
        private EventAppLib.Model.Event _event;

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public EventAppLib.Model.Event Event { get; set; }

        public LoggedInUser LoggedInUser { get; set; }

        public ProfileModel(LoggedInUser user)
        {
            LoggedInUser = user;
        }

        public IActionResult OnGet()
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }
    }
}
