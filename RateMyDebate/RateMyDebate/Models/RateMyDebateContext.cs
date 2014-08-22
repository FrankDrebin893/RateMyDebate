using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RateMyDebate.Models
{
    public class RateMyDebateContext :DbContext
    {
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }

        public DbSet<Inbox> Inbox { get; set; }

        public DbSet<Message> Message { get; set; }
        
    }
}