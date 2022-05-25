using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Admin
{
    public class AdminModel : PageModel
    {
        public LoggedInUser LoggedInUser { get; set; }

        public AdminModel(LoggedInUser loggedInUser)
        {
            LoggedInUser = loggedInUser;
        }

        public IActionResult OnGet()
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            if (LoggedInUser.Roletype == 1)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
