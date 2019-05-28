using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        public string Text { get; set; }
        public int? PostID { get; set; }
        public int? OPID { get; set; }
        public int Upvotes { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
