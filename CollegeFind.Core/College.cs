using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace CollegeFind.Core
{
    public class College
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
