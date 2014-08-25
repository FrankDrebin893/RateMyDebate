using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateMyDebate.Models;

namespace RateMyDebate.ViewModels
{
    public class DebateUser
    {
       
        public List<UserInformation> User { get; set; }
        public List<Debate> Debate { get; set; }

        public List<Category> Categories { get; set; } 


    }
}