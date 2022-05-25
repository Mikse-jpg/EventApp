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
    public class EventSupplementModel : PageModel
    {
        private IService<User> _user;
        private IService<EventAppLib.Model.Event> _eventService;
        private IService<EventSupplement> _eventSupplementService;

        public EventSupplementModel(LoggedInUser user, IService<EventAppLib.Model.Event> eventService, IService<EventSupplement> eventSupplementService)
        {
            LoggedInUser = user;
            _eventService = eventService;
            _eventSupplementService = eventSupplementService;
        }

        [BindProperty]
        public EventAppLib.Model.Event Event
        {
            get;
            private set;
        }

        public LoggedInUser LoggedInUser { get; set; }

        [BindProperty]
        public EventSupplement EventSupplement { get; set; }


        public IActionResult OnGet(int id)
        {
            if (LoggedInUser.LoggedIn)
            {
                LoggedInUser.LoggedIn = false;
                return RedirectToPage("/Login");
            }

            id = LoggedInUser.Id;

            return Page();
        }

        public IActionResult OnPost(EventSupplement eventSupplement)
        {
            _eventSupplementService.Create(eventSupplement);


            return Page();
        }
    }
}
