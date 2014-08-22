namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        messageId = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        messageText = c.String(),
                        userInformationId_userInformationId = c.Int(),
                    })
                .PrimaryKey(t => t.messageId)
                .ForeignKey("dbo.UserInformations", t => t.userInformationId_userInformationId)
                .Index(t => t.userInformationId_userInformationId);
            
            AddColumn("dbo.Inboxes", "messageId_messageId", c => c.Int());
            CreateIndex("dbo.Inboxes", "messageId_messageId");
            AddForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages", "messageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages");
            DropForeignKey("dbo.Messages", "userInformationId_userInformationId", "dbo.UserInformations");
            DropIndex("dbo.Inboxes", new[] { "messageId_messageId" });
            DropIndex("dbo.Messages", new[] { "userInformationId_userInformationId" });
            DropColumn("dbo.Inboxes", "messageId_messageId");
            DropTable("dbo.Messages");
        }
    }
}
