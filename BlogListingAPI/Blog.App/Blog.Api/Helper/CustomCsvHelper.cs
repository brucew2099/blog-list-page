using Blog.Api.Models;

namespace Blog.Api.Helper
{
    public class CustomCsvHelper
    {
        public static List<BlogItem> ReadCsvFile()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            List<BlogItem> blogs = File.ReadAllLines(".\\Data\\blog.csv")
                                           .Skip(1)
                                           .Select(x => ReadFromCsv(x))
                                           .ToList();
            return blogs;
        }

        private static BlogItem ReadFromCsv(string csvLIne)
        {
            string[] line = csvLIne.Split(';');
            BlogItem blog = new BlogItem();
            blog.BlogId = new Guid(line[0]);
            blog.Title = line[1];
            blog.ShortDescription = line[2];
            blog.AuthorName = line[3];
            blog.Topic = line[4];
            blog.Image = line[5];
            blog.Contents = line[6];
            blog.PublishedDate = Convert.ToDateTime(line[7]);
            return blog;
        }
    }
}
