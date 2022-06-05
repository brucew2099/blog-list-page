using Blog.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Api.Controllers
{
    [Route("blog/topics")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogDbContext _db;
        public BlogController(BlogDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            return Ok(_db.Blogs?.ToList());
        }

        [HttpGet("{blogId}")]
        public IActionResult GetBlogByBlogId([FromQuery] string blogId)
        {
            BlogItem? blog = _db.Blogs?.Find(new Guid(blogId));

            if (blog == null) return NotFound($"No blog can be found with Blog ID: {blogId}");

            int blogCount = (int)(_db.Blogs?.Where(b => b.Topic.ToString() == blog.Topic).Count());

            return Ok(new ResponseFromGet(blog.Topic, blogCount, "null"));

        }

        [HttpPost]
        public void CreateBlog([FromBody] BlogItem blog)
        {
        }

        [HttpPut("{blogId}")]
        public void UpdateBlog(string blogId, [FromBody] BlogItem blog)
        {
        }

        [HttpDelete("{blogId}")]
        public void DeleteBlog(string blogId)
        {
        }
    }
}
