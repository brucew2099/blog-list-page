using Blog.Topics.Api.Helper;
using Microsoft.EntityFrameworkCore;

namespace Blog.Topics.Api.Data
{
    internal class DbInitializer
    {
        private ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            List<BlogTopic> _blogTopics = CustomCsvHelper.ReadCsvFile();
            modelBuilder.Entity<BlogTopic>().HasData(_blogTopics);
        }
    }
}