namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debates",
                c => new
                    {
                        DebateId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        ChatText = c.String(),
                        CreatorId = c.Int(nullable: false),
                        ChallengerId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DebateId);
            
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
                        accountId_accountId = c.Int(),
                        Debate_DebateId = c.Int(),
                        Debate_DebateId1 = c.Int(),
                        Debate_DebateId2 = c.Int(),
                    })
                .PrimaryKey(t => t.userInformationId)
                .ForeignKey("dbo.UserModels", t => t.accountId_accountId)
                .ForeignKey("dbo.Debates", t => t.Debate_DebateId)
                .ForeignKey("dbo.Debates", t => t.Debate_DebateId1)
                .ForeignKey("dbo.Debates", t => t.Debate_DebateId2)
                .Index(t => t.accountId_accountId)
                .Index(t => t.Debate_DebateId)
                .Index(t => t.Debate_DebateId1)
                .Index(t => t.Debate_DebateId2);
            
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
            DropForeignKey("dbo.UserInformations", "Debate_DebateId2", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "Debate_DebateId1", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "Debate_DebateId", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "accountId_accountId", "dbo.UserModels");
            DropIndex("dbo.Messages", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Messages", new[] { "inboxId_inboxId" });
            DropIndex("dbo.Inboxes", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId2" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId1" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId" });
            DropIndex("dbo.UserInformations", new[] { "accountId_accountId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Inboxes");
            DropTable("dbo.UserModels");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Debates");
        }
    }
}
