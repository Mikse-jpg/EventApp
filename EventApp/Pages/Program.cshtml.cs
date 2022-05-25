using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages
{
    public class ProgramModel : PageModel
    {
        private IService<EventAppLib.Model.Event> _events;

        public ProgramModel(IService<EventAppLib.Model.Event> events, LoggedInUser loggedInUser)
        {
            _events = events;
            LoggedInUser = loggedInUser;
        }


        [BindProperty]
        public List<EventAppLib.Model.Event> Events { get; set; }

        public LoggedInUser LoggedInUser { get; set; }


        public IActionResult OnGet(int id)
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            Events = _events.GetAllSorted();
            return Page();
        }
    }
}
