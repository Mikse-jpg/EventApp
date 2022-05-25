using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Admin
{
    public class StatisticsModel : PageModel
    {

        private IService<EventAppLib.Model.Event> _events;

        public LoggedInUser LoggedInUser { get; set; }

        [BindProperty]
        public List<EventAppLib.Model.Event> Events { get; set; }

        public StatisticsModel(IService<EventAppLib.Model.Event> events, LoggedInUser loggedInUser)
        {
            _events = events;
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

            Events = _events.GetAll();
            return Page();
        }
    }
}
