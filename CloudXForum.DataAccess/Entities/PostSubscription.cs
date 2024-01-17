namespace CloudXForum.DataAccess.Entities
{
    public class PostSubscription
    {
        public int Id { get; set; }

        // Foreign key properties
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
