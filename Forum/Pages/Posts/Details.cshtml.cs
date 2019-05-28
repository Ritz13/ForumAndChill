using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum.Models;
using Microsoft.AspNetCore.Http;

namespace Forum.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly Forum.Models.ForumContext context;

        public DetailsModel(Forum.Models.ForumContext _context)
        {
            context = _context;
        }


        public IList<User> Users { get; set; }
        public Post Post { get; set; }
        public IList<Comment> Comments { get; set; }

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

            Comments = await context.Comment.Where(m => m.PostID == id).ToListAsync();
            await context.SaveChangesAsync();

            Users = await context.User.ToListAsync();
            await context.SaveChangesAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            Comment newComment = new Comment();
            newComment.Text = newCommentText;
            newComment.OPID = HttpContext.Session.GetInt32("User");
            newComment.PostID = id;
            newComment.DatePosted = DateTime.Now;

            context.Comment.Add(newComment);
            await context.SaveChangesAsync();

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            IUrlHelper MyUrl = Url;
            string My = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.ToString() + HttpContext.Request.Path + HttpContext.Request.QueryString;
            return Redirect(My);
        }

    }
}
