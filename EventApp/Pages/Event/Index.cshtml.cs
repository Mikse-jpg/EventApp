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
        private IEventService _events;

        public IndexModel(IEventService db)
        {
            _events = db;
        }
        public void OnGet()
        {
            Events = _events.GetAllEvents();
        }

        public List<EventAppLib.Model.Event> Events { get; set; }
    }
}
