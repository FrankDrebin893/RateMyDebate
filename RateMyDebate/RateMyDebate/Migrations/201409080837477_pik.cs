namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInformations", "accountId_accountId", "dbo.UserModels");
            DropIndex("dbo.UserInformations", new[] { "accountId_accountId" });
            AddColumn("dbo.UserInformations", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserInformations", "userId");
            AddForeignKey("dbo.UserInformations", "userId", "dbo.UserModels", "accountId", cascadeDelete: true);
            DropColumn("dbo.UserInformations", "accountId_accountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInformations", "accountId_accountId", c => c.Int());
            DropForeignKey("dbo.UserInformations", "userId", "dbo.UserModels");
            DropIndex("dbo.UserInformations", new[] { "userId" });
            DropColumn("dbo.UserInformations", "userId");
            CreateIndex("dbo.UserInformations", "accountId_accountId");
            AddForeignKey("dbo.UserInformations", "accountId_accountId", "dbo.UserModels", "accountId");
        }
    }
}
