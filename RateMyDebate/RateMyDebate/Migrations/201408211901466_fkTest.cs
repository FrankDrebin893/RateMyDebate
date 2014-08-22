namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInformations", "UserModel_accountId", c => c.Int());
            CreateIndex("dbo.UserInformations", "UserModel_accountId");
            AddForeignKey("dbo.UserInformations", "UserModel_accountId", "dbo.UserModels", "accountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInformations", "UserModel_accountId", "dbo.UserModels");
            DropIndex("dbo.UserInformations", new[] { "UserModel_accountId" });
            DropColumn("dbo.UserInformations", "UserModel_accountId");
        }
    }
}
