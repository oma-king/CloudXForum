using CloudXForum.WebApi.Models.Forum;
using CloudXForum.WebApi.Models.Post;

namespace CloudXForum.WebApi.Models.Home;

public class HomeIndexModel
{
    public string SearchQuery { get; set; }
    public IEnumerable<PostListingModel> LatestPosts { get; set; }
    public IEnumerable<ForumListingModel> PopularForums { get; set; }
}