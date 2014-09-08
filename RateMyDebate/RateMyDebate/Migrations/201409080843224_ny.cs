namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ny : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Debates",
                c => new
                    {
                        DebateId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        ChatText = c.String(),
                        CreatorVotes = c.Int(nullable: false),
                        ChallengerVotes = c.Int(nullable: false),
                        Live = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        CategoryId_CategoryId = c.Int(),
                        ChallengerId_userInformationId = c.Int(),
                        CreatorId_userInformationId = c.Int(),
                    })
                .PrimaryKey(t => t.DebateId)
                .ForeignKey("dbo.Categories", t => t.CategoryId_CategoryId)
                .ForeignKey("dbo.UserInformations", t => t.ChallengerId_userInformationId)
                .ForeignKey("dbo.UserInformations", t => t.CreatorId_userInformationId)
                .Index(t => t.CategoryId_CategoryId)
                .Index(t => t.ChallengerId_userInformationId)
                .Index(t => t.CreatorId_userInformationId);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        userInformationId = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        lName = c.String(),
                        nickName = c.String(),
                        age = c.Int(nullable: false),
                        autobiography = c.String(),
                        Email = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userInformationId)
                .ForeignKey("dbo.UserModels", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        accountId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.accountId);
            
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        inboxId = c.Int(nullable: false, identity: true),
                        userInformationId_userInformationId = c.Int(),
                    })
                .PrimaryKey(t => t.inboxId)
                .ForeignKey("dbo.UserInformations", t => t.userInformationId_userInformationId)
                .Index(t => t.userInformationId_userInformationId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        messageId = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        messageText = c.String(),
                        inboxId_inboxId = c.Int(),
                        userInformationId_userInformationId = c.Int(),
                    })
                .PrimaryKey(t => t.messageId)
                .ForeignKey("dbo.Inboxes", t => t.inboxId_inboxId)
                .ForeignKey("dbo.UserInformations", t => t.userInformationId_userInformationId)
                .Index(t => t.inboxId_inboxId)
                .Index(t => t.userInformationId_userInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "userInformationId_userInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Messages", "inboxId_inboxId", "dbo.Inboxes");
            DropForeignKey("dbo.Inboxes", "userInformationId_userInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Debates", "CreatorId_userInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Debates", "ChallengerId_userInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.UserInformations", "userId", "dbo.UserModels");
            DropForeignKey("dbo.Debates", "CategoryId_CategoryId", "dbo.Categories");
            DropIndex("dbo.Messages", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Messages", new[] { "inboxId_inboxId" });
            DropIndex("dbo.Inboxes", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Debates", new[] { "CreatorId_userInformationId" });
            DropIndex("dbo.Debates", new[] { "ChallengerId_userInformationId" });
            DropIndex("dbo.UserInformations", new[] { "userId" });
            DropIndex("dbo.Debates", new[] { "CategoryId_CategoryId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Inboxes");
            DropTable("dbo.UserModels");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Debates");
            DropTable("dbo.Categories");
        }
    }
}