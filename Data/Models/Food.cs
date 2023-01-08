using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }


        [Required, StringLength(400, MinimumLength = 10, ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }


        [Required, StringLength(100, MinimumLength = 15, ErrorMessage = "The Image field is required.")]
        public string Image { get; set; }


        [Required, Range(0, 2000)]
        public decimal Price { get; set; }

        public int Weight { get; set; }

        [Required, StringLength(100, MinimumLength = 15, ErrorMessage = "The Category field is required.")]
        public string Category { get; set; }
    }
}