using System.ComponentModel.DataAnnotations;

namespace Blog.Topics.Api.Data
{
    public class BlogTopic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string? Topic { get; set; }
        public DateTime PublishedDate { get; set; }

        public BlogTopic()
        {
            this.AuthorName = "Anonymous";
        }

    }
}
