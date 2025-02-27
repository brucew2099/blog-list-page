﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Models
{
    public class ResponseFromGet
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AggregateCount { get; set; }
        [Required]
        public string Style { get; set; }

        public ResponseFromGet()
        {
            this.Name = "";
            this.AggregateCount = 0;
            if (string.IsNullOrEmpty(Style))
                Style = "null";
        }

        public ResponseFromGet(string name, int aggregateCount, string style)
        {
            this.Name = name;
            this.AggregateCount = aggregateCount;
            this.Style = style;
        }
    }
}
