using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventApp.Pages.Admin
{
    public class StatisticsModel : PageModel
    {

        private IService<EventAppLib.Model.Event> _events;

        [BindProperty]
        public List<EventAppLib.Model.Event> Events { get; set; }

        public StatisticsModel(IService<EventAppLib.Model.Event> events)
        {
            _events = events;
        }

        public void OnGet()
        {
            Events = _events.GetAll();
        }
    }
}
