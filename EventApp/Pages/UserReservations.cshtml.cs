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
    public class UserReservationsModel : PageModel
    {
        private User _user;
        private EventAppLib.Model.Event _event;
        private IService<Participants> _participantsService;

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public EventAppLib.Model.Event Event { get; set; }

        [BindProperty]
        public List<Participants> Participants { get; set; }

        public LoggedInUser LoggedInUser { get; set; }

        public UserReservationsModel(LoggedInUser user, IService<Participants> participants)
        {
            LoggedInUser = user;
            _participantsService = participants;

        }

        public IActionResult OnGet(int id)
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            id = LoggedInUser.Id;
            Participants = _participantsService.GetAll();

            return Page();
        }
    }
}
