namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
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
                        CreatorIdId = c.Int(nullable: false),
                        ChallengerIdId = c.Int(nullable: false),
                        CategoryIdId = c.Int(nullable: false),
                        Subject = c.String(),
                        Description = c.String(),
                        ChatText = c.String(),
                        CreatorVotes = c.Int(nullable: false),
                        ChallengerVotes = c.Int(nullable: false),
                        Live = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DebateId)
                .ForeignKey("dbo.Categories", t => t.CategoryIdId)
                .ForeignKey("dbo.UserInformations", t => t.ChallengerIdId)
                .ForeignKey("dbo.UserInformations", t => t.CreatorIdId)
                .Index(t => t.CategoryIdId)
                .Index(t => t.ChallengerIdId)
                .Index(t => t.CreatorIdId);
            
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
                        UserModel_accountId = c.Int(),
                    })
                .PrimaryKey(t => t.userInformationId)
                .ForeignKey("dbo.UserModels", t => t.UserModel_accountId)
                .ForeignKey("dbo.UserModels", t => t.userId)
                .Index(t => t.UserModel_accountId)
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
            DropForeignKey("dbo.Debates", "CreatorIdId", "dbo.UserInformations");
            DropForeignKey("dbo.Debates", "ChallengerIdId", "dbo.UserInformations");
            DropForeignKey("dbo.UserInformations", "userId", "dbo.UserModels");
            DropForeignKey("dbo.UserInformations", "UserModel_accountId", "dbo.UserModels");
            DropForeignKey("dbo.Debates", "CategoryIdId", "dbo.Categories");
            DropIndex("dbo.Messages", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Messages", new[] { "inboxId_inboxId" });
            DropIndex("dbo.Inboxes", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Debates", new[] { "CreatorIdId" });
            DropIndex("dbo.Debates", new[] { "ChallengerIdId" });
            DropIndex("dbo.UserInformations", new[] { "userId" });
            DropIndex("dbo.UserInformations", new[] { "UserModel_accountId" });
            DropIndex("dbo.Debates", new[] { "CategoryIdId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Inboxes");
            DropTable("dbo.UserModels");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Debates");
            DropTable("dbo.Categories");
        }
    }
}
