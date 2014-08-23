namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages");
            DropIndex("dbo.Inboxes", new[] { "messageId_messageId" });
            AddColumn("dbo.Messages", "inboxId_inboxId", c => c.Int());
            CreateIndex("dbo.Messages", "inboxId_inboxId");
            AddForeignKey("dbo.Messages", "inboxId_inboxId", "dbo.Inboxes", "inboxId");
            DropColumn("dbo.Inboxes", "messageId_messageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inboxes", "messageId_messageId", c => c.Int());
            DropForeignKey("dbo.Messages", "inboxId_inboxId", "dbo.Inboxes");
            DropIndex("dbo.Messages", new[] { "inboxId_inboxId" });
            DropColumn("dbo.Messages", "inboxId_inboxId");
            CreateIndex("dbo.Inboxes", "messageId_messageId");
            AddForeignKey("dbo.Inboxes", "messageId_messageId", "dbo.Messages", "messageId");
        }
    }
}
