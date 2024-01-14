﻿using CloudXForum.DataAccess.Entities;

namespace CloudXForum.DataAccess.Services;

public interface IPost
{
    Task Add(Post post);
    Task AddReply(PostReply reply);
    Task Archive(int id);
    Task Delete(int id);
    Task Edit(Post post);
    Task<Post?> GetById(int id);
    Task<int> GetReplyCount(int id);
    IEnumerable<Post> GetAll();
    IEnumerable<Post> GetPostsByUserId(int id);
    IEnumerable<Post> GetPostsByForumId(int id);
    IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
    IEnumerable<Post> GetFilteredPosts(string searchQuery);
    IEnumerable<Post> GetLatestPosts(int numberPosts);
    Task UnArchive(int id);
}