namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inboxUnit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inboxes", "userInformationId_userInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Messages", "userInformationId_userInformationId", "dbo.UserInformations");
            DropForeignKey("dbo.Messages", "inboxId_inboxId", "dbo.Inboxes");
            DropIndex("dbo.Inboxes", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Messages", new[] { "userInformationId_userInformationId" });
            DropIndex("dbo.Messages", new[] { "inboxId_inboxId" });
            RenameColumn(table: "dbo.Messages", name: "inboxId_inboxId", newName: "inboxKey");
            AddColumn("dbo.Inboxes", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "userId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "inboxKey", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "userId");
            CreateIndex("dbo.Inboxes", "userId");
            CreateIndex("dbo.Messages", "inboxKey");
            AddForeignKey("dbo.Messages", "userId", "dbo.UserInformations", "userInformationId");
            AddForeignKey("dbo.Inboxes", "userId", "dbo.UserInformations", "userInformationId");
            AddForeignKey("dbo.Messages", "inboxKey", "dbo.Inboxes", "inboxId");
            DropColumn("dbo.Inboxes", "userInformationId_userInformationId");
            DropColumn("dbo.Messages", "userInformationId_userInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "userInformationId_userInformationId", c => c.Int());
            AddColumn("dbo.Inboxes", "userInformationId_userInformationId", c => c.Int());
            DropForeignKey("dbo.Messages", "inboxKey", "dbo.Inboxes");
            DropForeignKey("dbo.Inboxes", "userId", "dbo.UserInformations");
            DropForeignKey("dbo.Messages", "userId", "dbo.UserInformations");
            DropIndex("dbo.Messages", new[] { "inboxKey" });
            DropIndex("dbo.Inboxes", new[] { "userId" });
            DropIndex("dbo.Messages", new[] { "userId" });
            AlterColumn("dbo.Messages", "inboxKey", c => c.Int());
            DropColumn("dbo.Messages", "userId");
            DropColumn("dbo.Inboxes", "userId");
            RenameColumn(table: "dbo.Messages", name: "inboxKey", newName: "inboxId_inboxId");
            CreateIndex("dbo.Messages", "inboxId_inboxId");
            CreateIndex("dbo.Messages", "userInformationId_userInformationId");
            CreateIndex("dbo.Inboxes", "userInformationId_userInformationId");
            AddForeignKey("dbo.Messages", "inboxId_inboxId", "dbo.Inboxes", "inboxId");
            AddForeignKey("dbo.Messages", "userInformationId_userInformationId", "dbo.UserInformations", "userInformationId");
            AddForeignKey("dbo.Inboxes", "userInformationId_userInformationId", "dbo.UserInformations", "userInformationId");
        }
    }
}
