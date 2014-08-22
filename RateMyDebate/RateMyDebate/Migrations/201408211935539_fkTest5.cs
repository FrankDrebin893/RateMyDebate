namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserModels", "userInformationId_userInformationId", "dbo.UserInformations");
            DropIndex("dbo.UserModels", new[] { "userInformationId_userInformationId" });
            RenameColumn(table: "dbo.UserInformations", name: "UserModel_accountId", newName: "accountId_accountId");
            DropColumn("dbo.UserModels", "userInformationId_userInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "userInformationId_userInformationId", c => c.Int());
            RenameColumn(table: "dbo.UserInformations", name: "accountId_accountId", newName: "UserModel_accountId");
            CreateIndex("dbo.UserModels", "userInformationId_userInformationId");
            AddForeignKey("dbo.UserModels", "userInformationId_userInformationId", "dbo.UserInformations", "userInformationId");
        }
    }
}
