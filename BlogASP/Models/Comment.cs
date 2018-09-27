using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogASP.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public int Created_at { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public virtual Post Post { get; set; }
    }
}