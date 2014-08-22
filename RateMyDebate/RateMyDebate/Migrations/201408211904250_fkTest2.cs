namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "userInformationId_userInformationId", c => c.Int());
            CreateIndex("dbo.UserModels", "userInformationId_userInformationId");
            AddForeignKey("dbo.UserModels", "userInformationId_userInformationId", "dbo.UserInformations", "userInformationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModels", "userInformationId_userInformationId", "dbo.UserInformations");
            DropIndex("dbo.UserModels", new[] { "userInformationId_userInformationId" });
            DropColumn("dbo.UserModels", "userInformationId_userInformationId");
        }
    }
}
