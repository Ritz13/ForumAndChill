using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Forum.Models;

namespace Forum.Pages.Home
{
    public class LoginModel : PageModel
    {
        public ForumContext context;

        [BindProperty]
        public User User { get; set; }

        public LoginModel(ForumContext _context)
        {
            context = _context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach(User user in context.User)
            {
                if(user.Username == User.Username && user.Password == User.Password)
                {
                    return Redirect("~/Posts/Index");
                }
            }

            return Page();
        }
    }
}