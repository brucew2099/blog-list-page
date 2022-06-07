using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogListing.Models
{
    public class Blog
    {
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public string AuthorName { get; set; }
        public string Topic { get; set; }
        public string Image { get; set; }
        public string Contents { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
