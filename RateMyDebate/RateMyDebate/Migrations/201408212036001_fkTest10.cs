namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages");
            DropIndex("dbo.Inboxes", new[] { "messageId_messageId" });
            AlterColumn("dbo.Messages", "messageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "messageId");
            AddForeignKey("dbo.Messages", "messageId", "dbo.Inboxes", "inboxId");
            DropColumn("dbo.Inboxes", "messageId_messageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inboxes", "messageId_messageId", c => c.Int());
            DropForeignKey("dbo.Messages", "messageId", "dbo.Inboxes");
            DropIndex("dbo.Messages", new[] { "messageId" });
            AlterColumn("dbo.Messages", "messageId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Inboxes", "messageId_messageId");
            AddForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages", "messageId");
        }
    }
}
