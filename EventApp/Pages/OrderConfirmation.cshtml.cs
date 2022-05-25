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
    public class OrderConfirmationModel : PageModel
    {
        private IService<EventAppLib.Model.Event> _eventService;
        private IService<Participants> _participantsService;
        private IService<EventSupplement> _eventSupplementService;

        [BindProperty]
        public EventAppLib.Model.Event Event
        {
            get;
            private set;
        }

        [BindProperty]
        public Participants Participants { get; set; }

        [BindProperty]
        public LoggedInUser LoggedInUser { get; set; }

        [BindProperty]
        public EventSupplement EventSupplement { get; set; }

        public OrderConfirmationModel(LoggedInUser user, IService<EventAppLib.Model.Event> eventService, IService<Participants> participantsService, IService<EventSupplement> eventSupplementService)
        {
            
            LoggedInUser = user;
            _eventService = eventService;
            _participantsService = participantsService;
            _eventSupplementService = eventSupplementService;
        }

        public void OnGet(int id)
        {
            

            Event = _eventService.GetById(id);
            Participants = _participantsService.GetById(id);

            EventSupplement = _eventSupplementService.GetById(LoggedInUser.Id);

        }
    }
}
