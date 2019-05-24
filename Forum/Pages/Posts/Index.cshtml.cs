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
    public class IndexModel : PageModel
    {
        private readonly Forum.Models.ForumContext context;

        public IndexModel(Forum.Models.ForumContext _context)
        {
            context = _context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await context.Post.ToListAsync();
            await context.SaveChangesAsync();
        }
    }
}
