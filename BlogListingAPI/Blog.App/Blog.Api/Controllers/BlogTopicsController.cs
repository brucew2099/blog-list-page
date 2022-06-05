using Blog.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllBlogTopics()
        {
            List<ResponseFromGet> topicList = new List<ResponseFromGet>();
            List<BlogItem> blogs = _context.Blogs.ToList();
            ResponseFromGet temp;

            if (blogs == null) return NotFound("No blogs found");

            foreach(BlogItem blog in blogs)
            {
                int blogCount = (int)(_context.Blogs?.Where(b => b.Topic.ToString() == blog.Topic).Count());
                temp = new ResponseFromGet(blog.Topic, blogCount, "null");
                topicList.Add(temp);
            }

            // There might be duplicates in topicsList depending on how the data is being stored
            var returnedObject = topicList.GroupBy(t => t.Name).Select(x => x.FirstOrDefault());

            return Ok(returnedObject);
        }

        [HttpGet("{blogId}")]
        public IActionResult GetBlogTopicsByBlogId(string blogId)
        {
            BlogItem? blog = _context.Blogs?.Find(new Guid(blogId));

            if (blog == null) return NotFound($"No blog can be found with Blog ID: {blogId}");

            int blogCount = (int)(_context.Blogs?.Where(b => b.Topic.ToString() == blog.Topic).Count());

            return Ok(new ResponseFromGet(blog.Topic, blogCount, "null"));

        }
    }
}
