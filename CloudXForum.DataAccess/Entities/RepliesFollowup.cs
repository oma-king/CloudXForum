
namespace CloudXForum.DataAccess.Entities
{
    public class RepliesFollowup
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public bool IsArchived { get; set; }

        // Foreign key properties

        public int PostReplyId { get; set; }
        public PostReply PostReply { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
