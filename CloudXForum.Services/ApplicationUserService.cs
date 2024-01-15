using Microsoft.EntityFrameworkCore;
using CloudXForum.DataAccess;
using CloudXForum.DataAccess.Entities;
using CloudXForum.DataAccess.Services;

namespace CloudXForum.Services;

public class ApplicationUserService : IApplicationUser
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationUserService(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(ApplicationUser user)
    {
        _context.Add(user);
        await _unitOfWork.Commit();
    }

    public async Task Edit(ApplicationUser user)
    {
        var userOld = await GetById(user.Id);
        if (userOld == null) return;
        if (user.UserDescription != null) userOld.UserDescription = user.UserDescription;
        if (!string.IsNullOrEmpty(user.ProfileImageUrl)) userOld.ProfileImageUrl = user.ProfileImageUrl;
        _context.ApplicationUsers.Update(userOld);
        await _unitOfWork.Commit();
    }

    public async Task Deactivate(ApplicationUser user)
    {
        user.IsActive = false;
        _context.Update(user);
        await _unitOfWork.Commit();
    }

    public async Task LockUser(ApplicationUser user)
    {
        user.IsActive = false;
        user.LockoutEnd = DateTimeOffset.Now.AddDays(5);
        _context.Update(user);
        await _unitOfWork.Commit();
    }

    public async Task UnlockUser(ApplicationUser user)
    {
        user.IsActive = true;
        user.LockoutEnd = null;
        _context.Update(user);
        await _unitOfWork.Commit();
    }

    public IEnumerable<ApplicationUser> GetAll()
    {
        return _context.ApplicationUsers;
    }

    public async Task<ApplicationUser?> GetById(string id)
    {
        return await _context.ApplicationUsers.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task UpdateUserRating(string userId, Type type)
    {
        var user = await GetById(userId);
        if (user == null) return;
        user.Rating = CalculateUserRating(type, user.Rating);
        await _unitOfWork.Commit();
    }

    private static int CalculateUserRating(Type type, int userRating)
    {
        var inc = 0;
        if (type == typeof(Post)) inc = 1;
        if (type == typeof(PostReply)) inc = 3;
        return userRating + inc;
    }

    public static string GetLevelFromRating(int userRating)
    {
        if (userRating < 50)
        {
            return "Newbie";
        }
        else if (userRating < 200)
        {
            return "Contributor";
        }
        else if (userRating < 500)
        {
            return "Regular";
        }
        else if (userRating < 1000)
        {
            return "Expert";
        }
        else
        {
            return "Master";
        }
    }
}