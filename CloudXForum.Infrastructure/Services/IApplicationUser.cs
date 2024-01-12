﻿using CloudXForum.Infrastructure.Entities;

namespace CloudXForum.Infrastructure.Services;

public interface IApplicationUser
{
    Task<ApplicationUser?> GetById(string id);
    IEnumerable<ApplicationUser> GetAll();
    Task Add(ApplicationUser user);
    Task Edit(ApplicationUser user);
    Task Deactivate(ApplicationUser user);
    Task UpdateUserRating(string id, Type type);
}