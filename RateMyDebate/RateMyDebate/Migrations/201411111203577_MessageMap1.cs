namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageMap1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageMaps",
                c => new
                    {
                        MessageId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        InboxId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageId, t.UserId })
                .ForeignKey("dbo.Inboxes", t => t.InboxId)
                .Index(t => t.InboxId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageMaps", "InboxId", "dbo.Inboxes");
            DropIndex("dbo.MessageMaps", new[] { "InboxId" });
            DropTable("dbo.MessageMaps");
        }
    }
}
