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

        public EnlistModel(IService<EventAppLib.Model.Event> eventService)
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

        public void OnPost()
        {
            _eventService.Create(Event);
            
        }

        protected void AcceptClickedYes(object sender, EventArgs e)
        {
            var x = 1;
        }
    }
}
