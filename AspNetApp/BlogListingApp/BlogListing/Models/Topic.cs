using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogListing.Models
{
    public class Topic
    {
        [Display(Name = "Title Name")]
        public string Name { get; set; }

        [Display(Name = "Number of Posts")]
        public int AggregateCount { get; set; }
        public string Style { get; set; }
    }
}
