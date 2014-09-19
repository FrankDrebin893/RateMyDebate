namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Receiver", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "subject", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "messageText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "messageText", c => c.String());
            AlterColumn("dbo.Messages", "subject", c => c.String());
            AlterColumn("dbo.Messages", "Receiver", c => c.String());
        }
    }
}
