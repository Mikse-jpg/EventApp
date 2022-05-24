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
    public class CreateEventModel : PageModel
    {
        private IService<EventAppLib.Model.Event> _events;


        [BindProperty]
        public EventAppLib.Model.Event Event { get; set; }

        public CreateEventModel(IService<EventAppLib.Model.Event> events)
        {
            _events = events;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(EventAppLib.Model.Event events)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_events.GetAll().Count == 0)
            {
                Event.Id = 1;

            }
            else
            {
                Event.Id = _events.GetAll().Count + 1;
            }

            _events.Create(Event);
            return RedirectToPage("/Index");
        }
    }
}
