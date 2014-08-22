﻿using System;
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
        public String userName { get; set; }
        public String Password { get; set; }

        public ICollection<UserInformation> UserInformation { get; set; }

    }
}