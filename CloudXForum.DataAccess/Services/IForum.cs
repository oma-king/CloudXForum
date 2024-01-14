using CloudXForum.DataAccess.Entities;

namespace CloudXForum.DataAccess.Services;

public interface IForum
{
    Task Create(Forum forum);
    Task Delete(int id);
    Task Edit(Forum forum);
    Task<IEnumerable<ApplicationUser>> GetActiveUsers(int id);
    IEnumerable<Forum> GetAll();
    Task<Forum?> GetById(int id);
    Task<bool> HasRecentPost(int id);
    public IEnumerable<Forum> GetPopularForums(int numberForums);
}