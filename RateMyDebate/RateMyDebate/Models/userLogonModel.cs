using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateMyDebate.Models
{
    public class userLogonModel
    {


        [Display(Name = "User name")]
        [Required]
        [Remote("ValidateUserName", "User", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public String userName { get; set; }

        [Display(Name = "Password")]
        [Required]
        public String Password { get; set; }

        public String Salt { get; set; }
    }
}