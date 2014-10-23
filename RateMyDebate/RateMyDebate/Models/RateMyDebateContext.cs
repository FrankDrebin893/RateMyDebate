using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<Debate> Debate { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<UserInformation>()
            .HasRequired(u => u.accountId)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
    }


}