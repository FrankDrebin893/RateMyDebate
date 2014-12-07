using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [StringLength(30, ErrorMessage = "Not allowed to use more than 30 characters in a category name")]
        public String CategoryName { get; set; }
    }
}