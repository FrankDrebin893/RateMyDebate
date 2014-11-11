namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageMap2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MessageMaps", "MessageId");
            CreateIndex("dbo.MessageMaps", "UserId");
            AddForeignKey("dbo.MessageMaps", "MessageId", "dbo.Messages", "messageId");
            AddForeignKey("dbo.MessageMaps", "UserId", "dbo.UserInformations", "userInformationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageMaps", "UserId", "dbo.UserInformations");
            DropForeignKey("dbo.MessageMaps", "MessageId", "dbo.Messages");
            DropIndex("dbo.MessageMaps", new[] { "UserId" });
            DropIndex("dbo.MessageMaps", new[] { "MessageId" });
        }
    }
}
