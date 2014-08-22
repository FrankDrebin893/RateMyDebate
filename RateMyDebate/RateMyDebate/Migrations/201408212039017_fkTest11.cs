namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "messageId", "dbo.Inboxes");
            DropIndex("dbo.Messages", new[] { "messageId" });
            AddColumn("dbo.Inboxes", "messageId_messageId", c => c.Int());
            AlterColumn("dbo.Messages", "messageId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Inboxes", "messageId_messageId");
            AddForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages", "messageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages");
            DropIndex("dbo.Inboxes", new[] { "messageId_messageId" });
            AlterColumn("dbo.Messages", "messageId", c => c.Int(nullable: false));
            DropColumn("dbo.Inboxes", "messageId_messageId");
            CreateIndex("dbo.Messages", "messageId");
            AddForeignKey("dbo.Messages", "messageId", "dbo.Inboxes", "inboxId");
        }
    }
}
