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
    public class EventDetailedModel : PageModel
    {
        private IService<EventAppLib.Model.Event> _eventService;
        

        public EventDetailedModel(IService<EventAppLib.Model.Event> eventService)
        {
            _eventService = eventService;
            
        }

        [BindProperty]
        public EventAppLib.Model.Event Event
        {
            get;
            private set;
        }

        public void OnGet(int id)
        {
            Event = _eventService.GetById(id);
            
        }
    }
}
