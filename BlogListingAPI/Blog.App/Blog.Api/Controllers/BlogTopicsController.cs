using Blog.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Api.Controllers
{
    [Route("blog/topics")]
    [ApiController]
    public class BlogTopicsController : ControllerBase
    {
        private readonly BlogDbContext _context;
        public BlogTopicsController(BlogDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogTopics()
        {
            List<ResponseFromGet> topicList = new List<ResponseFromGet>();
            List<BlogItem> blogs = await _context.Blogs.ToListAsync();
            ResponseFromGet temp;

            if (blogs == null) return NotFound("No blogs found");

            foreach (BlogItem blog in blogs)
            {
                int blogCount = await (Task<int>)(_context.Blogs?.Where(b => b.Topic.ToString() == blog.Topic).CountAsync());
                temp = new ResponseFromGet(blog.Topic, blogCount, "null");
                topicList.Add(temp);
            }

            // There might be duplicates in topicsList depending on how the data is being stored
            var returnedObject = topicList.GroupBy(t => t.Name).Select(x => x.FirstOrDefault());

            return Ok(returnedObject);
        }

        [HttpGet("{blogId}")]
        public async Task<IActionResult> GetBlogTopicsByBlogId(string blogId)
        {
            BlogItem? blog = await _context.Blogs?.FirstOrDefaultAsync(x => x.BlogId.ToString() == blogId);

            if (blog == null) return NotFound($"No blog can be found with Blog ID: {blogId}");

            int blogCount = await (Task<int>)(_context.Blogs?.Where(b => b.Topic.ToString() == blog.Topic).CountAsync());

            return Ok(new ResponseFromGet(blog.Topic, blogCount, "null"));

        }

        [HttpGet("{topic}/blogs")]
        public async Task<IActionResult> GetBlogsFromTopic(string topic)
        {
            List<BlogItem>? blogs = await _context.Blogs?.Where(b => b.Topic.Equals(topic)).ToListAsync();

            if (blogs.Count() == 0) return NotFound($"No blog can be found with topic: {topic}");

            return Ok(blogs);
        }
    }
}
