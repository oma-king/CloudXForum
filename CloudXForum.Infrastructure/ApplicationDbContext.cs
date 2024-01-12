﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CloudXForum.Infrastructure.Entities;

namespace CloudXForum.Infrastructure;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Forum> Forums { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReply> PostReplies { get; set; }
}