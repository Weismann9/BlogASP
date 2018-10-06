using System.Collections.Generic;

namespace BlogASP.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        //Relations

        //Relation with table Post (many-to-many)
        public virtual ICollection<Post> Posts { get; set; }
    }
}