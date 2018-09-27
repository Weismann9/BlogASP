using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogASP.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Status { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}