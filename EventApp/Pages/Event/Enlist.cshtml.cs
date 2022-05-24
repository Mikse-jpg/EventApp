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
        private IService<Participants> _participantsService;
        
        public LoggedInUser LoggedInUser { get; set; }

        [BindProperty]
        public Participants Participants { get; set; }

        public EnlistModel(IService<EventAppLib.Model.Event> eventService, LoggedInUser loggedInUser)
        {
            _eventService = eventService;
            LoggedInUser = loggedInUser;
            _participantsService = new ParticipantsService();
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

        public IActionResult OnPost(EventAppLib.Model.Event events, Participants participants)
        {
            events.Id = Event.Id;
            
            Participants.EventId = Event.Id;
            Participants.Reservations = Event.Reservations;
            Participants.UserId = LoggedInUser.Id;

            _eventService.AddReservation(Event);
            _participantsService.AddParticipation(Participants);
            return RedirectToPage("/Index");

        }

    }
}
