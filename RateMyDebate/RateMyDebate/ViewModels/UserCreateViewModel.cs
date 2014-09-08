using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateMyDebate.Models;

namespace RateMyDebate.ViewModels
{
    public class UserCreateViewModel
    {
        public UserModel User { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}