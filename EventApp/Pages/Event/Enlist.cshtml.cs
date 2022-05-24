using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using EventAppLib.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Event
{
    public class EnlistModel : PageModel
    {
        private IService<EventAppLib.Model.Event> _eventService;
        
        public LoggedInUser LoggedInUser { get; set; }

        public EnlistModel(IService<EventAppLib.Model.Event> eventService, LoggedInUser loggedInUser)
        {
            _eventService = eventService;
            LoggedInUser = loggedInUser;
        }

        [BindProperty]
        public EventAppLib.Model.Event Event { get; set; }

        public IActionResult OnGet(int id)
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            Event = _eventService.GetById(id);
            return Page();
        }

        public IActionResult OnPost(EventAppLib.Model.Event events)
        {
            events.Id = Event.Id;

            _eventService.AddReservation(Event);
            return RedirectToPage("/Index");

        }

    }
}
