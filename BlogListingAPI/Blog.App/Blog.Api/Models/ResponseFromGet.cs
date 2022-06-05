using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class ResponseFromGet
    {
        private string topic;
        private int blogCount;
        private string v;

        [Required]
        public string Name { get; set; }

        [Required]
        public int AggregateCount { get; set; }
        public string Style { get; set; }

        public ResponseFromGet()
        {
            Name = "";
            if (string.IsNullOrEmpty(Style))
                Style = null;
        }

        public ResponseFromGet(string name, int aggregateCount, string style)
        {
            this.Name = name;
            this.AggregateCount = aggregateCount;
            this.Style = style;
        }
    }
}
