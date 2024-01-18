using CloudXForum.DataAccess.Entities;
using CloudXForum.UI.Models.Forum;
using CloudXForum.UI.Models.Post;

namespace CloudXForum.UI.Models.Home;

public class HomeIndexModel
{
    public string SearchQuery { get; set; }
    public IEnumerable<PostListingModel> LatestPosts { get; set; }
    public IEnumerable<ForumListingModel> PopularForums { get; set; }
    public List<NotificationDto> Notifications { get; set; }
}