using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class BlogContext : IdentityDbContext<User>
{
    public BlogContext(DbContextOptionsBuilder<BlogContext> optionsBuilder)
    {
        //
    }

    public DbSet<Article>? Articles { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Comment>? Comments { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<Tag>? Tags { get; set; }
}