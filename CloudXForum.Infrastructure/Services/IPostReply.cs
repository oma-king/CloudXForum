using CloudXForum.Infrastructure.Entities;

namespace CloudXForum.Infrastructure.Services;

public interface IPostReply
{
    Task Delete(int id);
    Task Edit(int id, string content);
    Task<PostReply?> GetById(int id);
}