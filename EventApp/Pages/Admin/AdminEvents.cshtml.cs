using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using EventAppLib.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Admin
{
    public class AdminEventsModel : PageModel
    {

        private IService<EventAppLib.Model.Event> _events;

        [BindProperty]
        public List<EventAppLib.Model.Event> Events { get; set; }

        public LoggedInUser LoggedInUser { get; set; }

        public AdminEventsModel(IService<EventAppLib.Model.Event> events, LoggedInUser loggedInUser)
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

        public void OnPost(EventAppLib.Model.Event events)
        {
            _events.Delete(events);


        }
    }
}
