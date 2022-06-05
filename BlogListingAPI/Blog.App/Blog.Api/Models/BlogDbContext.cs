using Blog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogItem>? Blogs { get; set; }

    }
}
