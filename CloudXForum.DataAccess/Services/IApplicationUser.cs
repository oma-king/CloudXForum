using CloudXForum.DataAccess.Entities;

namespace CloudXForum.DataAccess.Services;

public interface IApplicationUser
{
    Task<ApplicationUser?> GetById(string id);
    IEnumerable<ApplicationUser> GetAll();
    Task Add(ApplicationUser user);
    Task Edit(ApplicationUser user);
    Task Deactivate(ApplicationUser user);
    Task LockUser(ApplicationUser user);
    Task UnlockUser(ApplicationUser user);
    Task UpdateUserRating(string id, Type type);
}