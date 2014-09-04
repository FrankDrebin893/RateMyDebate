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
        
        [Display(Name = "First name")]
        public String fName { get; set; }
        public String lName { get; set; }
        [Display(Name = "Username")]
        public String nickName { get; set; }
        public int age { get; set; }
        public String autobiography { get; set; }
        public String Email { get; set; }
        
        [ForeignKey("accountId")]
        public int userId { get; set; }
        public UserModel accountId { get; set; }
    }
}