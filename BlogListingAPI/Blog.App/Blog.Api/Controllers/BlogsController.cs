using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Api.Models;
using System.Globalization;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private const string DateFormat = "MMMM d, yyyy";
        private readonly BlogDbContext _context;

        public BlogsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogItem>>> GetBlogs()
        {
            if (_context.Blogs == null)
            {
                return NotFound();
            }

            return await _context.Blogs.ToListAsync();
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<BlogItem>> GetBlogItem(Guid blogId)
        {
          if (_context.Blogs == null)
          {
              return NotFound();
          }
            var blogItem = await _context.Blogs.FindAsync(blogId);

            if (blogItem == null)
            {
                return NotFound();
            }

            return blogItem;
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{blogId}")]
        public async Task<IActionResult> PutBlogItem(Guid blogId, BlogItem blogItem)
        {
            if (blogId != blogItem.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(blogItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogItemExists(blogId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogItem>> PostBlogItem(BlogItem blogItem)
        {
          if (_context.Blogs == null)
          {
              return Problem("Entity set 'BlogDbContext.Blogs' is null.");
          }
            _context.Blogs.Add(blogItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogItem", new { blogId = blogItem.BlogId }, blogItem);
        }

        [HttpDelete("{blogId}")]
        public async Task<IActionResult> DeleteBlogItem(Guid blogId)
        {
            if (_context.Blogs == null)
            {
                return NotFound();
            }
            var blogItem = await _context.Blogs.FindAsync(blogId);
            if (blogItem == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blogItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogItemExists(Guid blogId)
        {
            return (_context.Blogs?.Any(e => e.BlogId == blogId)).GetValueOrDefault();
        }
    }
}
