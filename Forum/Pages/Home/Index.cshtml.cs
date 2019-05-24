using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Forum.Models;

namespace Forum.Pages.Home
{
    public class IndexModel : PageModel
    {
        public ForumContext context;

        public IndexModel(ForumContext _context)
        {
            context = _context;
        }
        public void OnGet()
        {

        }
    }
}