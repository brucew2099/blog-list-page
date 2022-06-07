using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Api.Models
{
    [Table("Blogs")]
    public class BlogItem
    {
        [Key]
        public Guid BlogId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Topic { get; set; }
        public string? Image { get; set; }
        public string? Contents { get; set; }
        public DateTime PublishedDate { get; set; }

        public BlogItem()
        {
            BlogId = Guid.NewGuid();
            Title = "To be Determined";
            AuthorName = "Anonymous";
            Topic = "Buckeye Stories";
        }
    }
}
