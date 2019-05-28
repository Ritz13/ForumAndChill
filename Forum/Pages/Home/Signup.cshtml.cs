using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Forum.Models;
using Microsoft.AspNetCore.Http;

namespace Forum.Pages.Home
{
    public class SignupModel : PageModel
    {
        public ForumContext context;

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public SignupModel(ForumContext _context)
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

            context.User.Add(User);
            await context.SaveChangesAsync();

            int newUserID = 0;
            foreach(User user in context.User)
            {
                if (user.Email == User.Email && user.DateCreated == User.DateCreated)
                    newUserID = user.ID;
            }
            HttpContext.Session.SetInt32("User", newUserID);
            return Redirect("~/Posts/Index");
        }
    }
}