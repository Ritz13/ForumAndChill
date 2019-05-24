using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum.Models;

namespace Forum.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly Forum.Models.ForumContext context;

        public DetailsModel(Forum.Models.ForumContext _context)
        {
            context = _context;
        }

        public Post Post { get; set; }

        [BindProperty]
        public string newCommentText { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await context.Post.FirstOrDefaultAsync(m => m.ID == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Comment newComment = new Comment();
            newComment.Text = newCommentText;
            context.Attach(Post).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
