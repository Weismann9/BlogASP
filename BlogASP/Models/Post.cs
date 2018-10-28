using System.Collections.Generic;

namespace BlogASP.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        //Relations

        ////Relation with table User (many-to-one)
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //Relation with table Comments (one-to-many)
        public virtual ICollection<Comment> Comments { get; set; }

        //Relation with table Tag (many-to-many)
        public virtual ICollection<Tag> Tags { get; set; }

    }
}