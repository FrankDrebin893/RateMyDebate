using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class UserInformation
    {
        [Key]
        public int userInformationId { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public String nickName { get; set; }
        public int age { get; set; }
        public String autobiography { get; set; }
        public String Email { get; set; }
        public UserModel accountId { get; set; }
       

    }
}