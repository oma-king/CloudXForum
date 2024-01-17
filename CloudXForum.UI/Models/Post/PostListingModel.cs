using CloudXForum.UI.Models.Forum;

namespace CloudXForum.UI.Models.Post;

public class PostListingModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int AuthorRating { get; set; }
    public string AuthorId { get; set; }
    public string DatePosted { get; set; }
    public ForumListingModel Forum { get; set; }
    public int RepliesCount { get; set; }
    public bool IsPostArchived { get; set; }
    public bool IsUserSubscribed { get; set; }
    public string AuthorLevel { get; set; }

}