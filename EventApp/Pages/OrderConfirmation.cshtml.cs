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
        private IService<User> _user;
        private LoggedInUser _loggedInUser;
        private IService<EventAppLib.Model.Event> _eventService;
        private IService<Participants> _participantsService;

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

        public OrderConfirmationModel(IService<User> user, LoggedInUser loggedInUser, IService<EventAppLib.Model.Event> eventService, IService<Participants> participantsService)
        {
            _user = user;
            _loggedInUser = loggedInUser;
            _eventService = eventService;
            _participantsService = participantsService;
        }

        public void OnGet(int id)
        {
            Event = _eventService.GetById(id);
            Participants = _participantsService.GetById(id);
            
        }
    }
}
