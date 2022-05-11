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
        private IEventService _eventService;

        public EnlistModel(IEventService eventService)
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
