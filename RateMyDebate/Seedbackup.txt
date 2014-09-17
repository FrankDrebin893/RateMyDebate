using RateMyDebate.Models;

namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RateMyDebate.Models.RateMyDebateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RateMyDebate.Models.RateMyDebateContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Debate.AddOrUpdate(
                d => d.DebateId,
                new Debate()
                {
                    DebateId = 1,
                    Live = true,
                    CreatorIdId = 1,
                    ChallengerIdId = 2,
                    CategoryIdId = 1,
                    Subject = "DickInButt",
                    Description = "How do I put my dick in but???!",
                    ChatText = "BUTT BUTTT BUTT BUTTBUTTBUTUUBUTBUTBUBUTBUTBUBUTBUTBUTBUBUTBUTBUTBUTBUBUTBUTBUBUTBUTBU",
                    DateTime = new DateTime(2014, 10, 19),
                    ChallengerVotes = 1000,
                    CreatorVotes = 2000
                },
                new Debate()
                {
                    DebateId = 2,
                    Live = true,
                    CreatorIdId = 1,
                    ChallengerIdId = 2,
                    CategoryIdId = 1,
                    Subject = "DickInButt",
                    Description = "How do I put my dick in but???!",
                    ChatText = "BUTT BUTTT BUTT BUTTBUTTBUTUUBUTBUTBUBUTBUTBUBUTBUTBUTBUBUTBUTBUTBUTBUBUTBUTBUBUTBUTBU",
                    DateTime = new DateTime(2014, 10, 19),
                    ChallengerVotes = 1000,
                    CreatorVotes = 2000
                },
                new Debate()
                {
                    DebateId = 3,
                    Live = true,
                    CreatorIdId = 1,
                    ChallengerIdId = 2,
                    CategoryIdId = 2,
                    Subject = "DickInButt",
                    Description = "How do I put my dick in but???!",
                    ChatText = "BUTT BUTTT BUTT BUTTBUTTBUTUUBUTBUTBUBUTBUTBUBUTBUTBUTBUBUTBUTBUTBUTBUBUTBUTBUBUTBUTBU",
                    DateTime = new DateTime(2014, 10, 19),
                    ChallengerVotes = 1000,
                    CreatorVotes = 2000
                });
            
            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Politics"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Atheism"
                });

            context.UserModel.AddOrUpdate(
                u => u.accountId,
                new UserModel()
                {
                    accountId = 1,
                    Password = "123456",
                    userName = "testuser"
                },
                new UserModel()
                {
                    accountId = 2,
                    Password = "123456",
                    userName = "testuser2"
                });

            context.UserInformation.AddOrUpdate(
                ui => ui.userInformationId,
                new UserInformation()
                {
                    age = 20,
                    autobiography = "HIHIHIH",
                    Email = "hehjejehej@hjehje.com",
                    fName = "Jen",
                    lName = "Jehnny",
                    nickName = "JehnJen",
                    userInformationId = 1,
                    userId = 1
                },
                new UserInformation()
                {
                    age = 20,
                    autobiography = "HIHIHIH",
                    Email = "hehjejehej@hjehje.com",
                    fName = "Jen",
                    lName = "Jehnny",
                    nickName = "JehnJen",
                    userInformationId = 2,
                    userId = 2
                });
        }
        }
    }
