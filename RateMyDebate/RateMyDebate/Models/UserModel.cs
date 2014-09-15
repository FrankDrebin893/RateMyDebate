using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class UserModel
    {
        [Key]
        public int accountId { get; set; }

        [Display(Name = "User name")]
        [Required]
        public String userName { get; set; }

        [Display(Name = "Password")]
        [Required]
        
        public String Password { get; set; }

        /*
        [NotMapped]
        [Compare("Password")]
 

        public String ConfirmPassword { get; set; }
        */
        public ICollection<UserInformation> UserInformation { get; set; }

    }
}