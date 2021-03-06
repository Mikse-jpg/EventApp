using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Pages.Services;

namespace EventApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public LoggedInUser LoggedInUser { get; set; }

        public IndexModel(ILogger<IndexModel> logger, LoggedInUser user)
        {
            _logger = logger;
            LoggedInUser = user;
        }

        public IActionResult OnGet()
        {
            if (!LoggedInUser.LoggedIn)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }
    }
}
