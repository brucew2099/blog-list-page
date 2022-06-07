using Blog.Api.Helper;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Models
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider, BlogDbContext context)
        {
            List<BlogItem> blogs = CustomCsvHelper.ReadCsvFile();
               
            if (!context.Blogs.Any())
            {
                context.Blogs.AddRangeAsync(blogs);
                context.SaveChanges();
            }
            
        }
    }
}