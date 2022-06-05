using Blog.Api.Helper;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Models
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            List<BlogItem> blogs = CustomCsvHelper.ReadCsvFile();
            using (var context = new BlogDbContext(serviceProvider.GetRequiredService<DbContextOptions<BlogDbContext>>()))
            {
                if (!context.Blogs.Any())
                {
                    context.Blogs.AddRange(blogs);
                    context.SaveChanges();
                }
            }
            
        }
    }
}