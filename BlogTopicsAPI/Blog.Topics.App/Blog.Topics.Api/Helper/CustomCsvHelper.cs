using Blog.Topics.Api.Data;

namespace Blog.Topics.Api.Helper
{
    public class CustomCsvHelper
    {
        public static List<BlogTopic> ReadCsvFile()
        {
            List<BlogTopic> blogTopics = File.ReadAllLines("")
                                           .Skip(1)
                                           .Select(v => ReadFromCsv(v))
                                           .ToList();
            return blogTopics;
        }

        private static BlogTopic ReadFromCsv(string csvLIne)
        {
            string[] line = csvLIne.Split('\u002C');
            BlogTopic blogTopic = new BlogTopic();
            blogTopic.Id = Convert.ToInt16(line[0]);
            blogTopic.Title = line[1];
            blogTopic.ShortDescription = line[2];
            blogTopic.AuthorName = line[3];
            blogTopic.Topic = line[4];
            blogTopic.PublishedDate = Convert.ToDateTime(line[5]);
            return blogTopic;
        }
    }
}
