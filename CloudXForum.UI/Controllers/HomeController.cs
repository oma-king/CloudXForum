using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using CloudXForum.DataAccess.Entities;
using CloudXForum.DataAccess.Services;
using CloudXForum.UI.Models;
using CloudXForum.UI.Models.Forum;
using CloudXForum.UI.Models.Home;
using CloudXForum.UI.Models.Post;
using Microsoft.AspNetCore.Identity;

namespace CloudXForum.UI.Controllers;

public class HomeController : Controller
{
    private readonly IForum _forumService;
    private readonly IPost _postService;
    private static UserManager<ApplicationUser> _userManager;

    public HomeController(IForum forumService, IPost postService,
        UserManager<ApplicationUser> userManager)
    {
        _forumService = forumService;
        _postService = postService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var model = BuildHomeIndexModel();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    private HomeIndexModel BuildHomeIndexModel()
    {
        var latestPosts = _postService.GetLatestPosts(5);
        var posts = latestPosts.Select(post => new PostListingModel
        {
            Id = post.Id,
            Title = post.Title,
            AuthorId = post.User.Id,
            Author = post.User.UserName,
            AuthorRating = post.User.Rating,
            DatePosted = post.Created.ToString(CultureInfo.CurrentCulture),
            RepliesCount = post.Replies.Count,
            Forum = GetForumListingForPost(post)
        });

        var popularForums = _forumService.GetPopularForums(5);
        var forums = popularForums
            .Select(async forum => new ForumListingModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
                NumberOfPosts = forum.Posts.Count,
                NumberOfUsers = (await _forumService.GetActiveUsers(forum.Id)).Count(),
                ImageUrl = forum.ImageUrl,
                HasRecentPosts = await _forumService.HasRecentPost(forum.Id)
            }).Select(t => t.Result);


        var userId = _userManager.GetUserId(User);

        var unreadMessages = _postService.GetUnreadMessages(userId);

        var notificationDtoList = unreadMessages.Select(notification => new NotificationDto
        {
            Content = notification.PostReply.Content,
            Title = notification.PostReply.Post.Title,
            UserName = notification.PostReply?.User?.UserName ?? "Unknown User",
            Id = notification.Id,
            PostId = notification.PostReply.Post.Id
        }).ToList();

       






        return new HomeIndexModel
        {
            LatestPosts = posts,
            PopularForums = forums,
            Notifications = notificationDtoList,
            SearchQuery = ""
        };
    }

    public IActionResult UnreadMessages()
    {
        var userId = _userManager.GetUserId(User);
        var unreadMessages = _postService.GetUnreadMessages(userId);

        var notificationDtoList = unreadMessages.Select(notification => new NotificationDto
        {
            Content = notification.PostReply.Content,
            Title = notification.PostReply.Post.Title,
            UserName = notification.PostReply?.User?.UserName ?? "Unknown User",
            Id = notification.Id,
            PostId = notification.PostReply.Post.Id
        }).ToList();

        // Return the updated notifications to the view
        return View(new HomeIndexModel { Notifications = notificationDtoList });
    }

    private static ForumListingModel GetForumListingForPost(Post post)
    {
        var forum = post.Forum;
        return new ForumListingModel
        {
            Name = forum.Title,
            ImageUrl = forum.ImageUrl,
            Id = forum.Id
        };
    }


    

    [HttpGet]
    public IActionResult GetUpdatedNotifications()
    {
        var userId = _userManager.GetUserId(User);
        var updatedNotifications = _postService.GetUnreadMessages(userId);

        var notificationDtoList = updatedNotifications.Select(notification => new NotificationDto
        {
            Content = notification.PostReply.Content,
            Title = notification.PostReply.Post.Title,
            UserName = notification.PostReply?.User?.UserName ?? "Unknown User",
            Id = notification.Id,
            PostId = notification.PostReply.Post.Id
        }).ToList();

        return Json(notificationDtoList);
    }


    [HttpPost]
    public async Task<IActionResult> MarkAsRead(int repliesfollowupid)
    {
        await _postService.MarkAsRead(repliesfollowupid);

        // Redirect to the unread messages page or another appropriate page
        //return RedirectToAction("UnreadMessages");
        return Json(new { success = true });
    }

}