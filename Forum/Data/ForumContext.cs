using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forum.Models;

namespace Forum.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext (DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public DbSet<Forum.Models.Post> Post { get; set; }

        public DbSet<Forum.Models.User> User { get; set; }

        public DbSet<Forum.Models.Comment> Comment { get; set; }
    }
}
