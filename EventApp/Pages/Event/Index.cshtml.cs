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
        private IService<EventAppLib.Model.Event> _events;
        private IService<User> _users;

        public IndexModel(IService<EventAppLib.Model.Event> events, IService<User> users)
        {
            _events = events;
            _users = users;
        }
        public void OnGet(int id)
        {
            Events = _events.GetAll();
            Users = _users.GetAll();
        }

        public List<EventAppLib.Model.Event> Events { get; set; }

        public List<User> Users { get; set; }
    }
}
