using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class UserInformation
    {
        [Key]
        public int userInformationId { get; set; }
        [Required]
        [Display(Name = "First name")]
        public String fName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public String lName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public String nickName { get; set; }

        [Display(Name = "Age")]
        [Required]
        public int age { get; set; }

        [Display(Name = "Autobiography")]
        [Required]
        public String autobiography { get; set; }

        [Display(Name = "Email")]
        [Required]
        public String Email { get; set; }
        
        [ForeignKey("accountId")]
        public int userId { get; set; }
        public UserModel accountId { get; set; }
    }
}