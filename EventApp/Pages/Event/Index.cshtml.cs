using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventAppLib.Model;

namespace EventApp.Pages.Event
{
    public class IndexModel : PageModel
    {
        private IService<EventAppLib.Model.Event> _events;

        public LoggedInUser LoggedInUser { get; set; }

        [BindProperty]
        public List<EventAppLib.Model.Event> Events { get; set; }

        public IndexModel(IService<EventAppLib.Model.Event> events, LoggedInUser loggedInUser)
        {
            _events = events;
            LoggedInUser = loggedInUser;
        }
        public IActionResult OnGet(int id)
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            Events = _events.GetAll();
            return Page();
        }

        

        
    }
}
