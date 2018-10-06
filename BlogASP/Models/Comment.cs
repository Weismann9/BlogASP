namespace BlogASP.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Created_at { get; set; }

        //Relations

        //Relation with table Post (many-to-one)
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}