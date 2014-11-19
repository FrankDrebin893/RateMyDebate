namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Results2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Results", "WinnerId");
            CreateIndex("dbo.Results", "LoserId");
            AddForeignKey("dbo.Results", "LoserId", "dbo.UserInformations", "userInformationId");
            AddForeignKey("dbo.Results", "WinnerId", "dbo.UserInformations", "userInformationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "WinnerId", "dbo.UserInformations");
            DropForeignKey("dbo.Results", "LoserId", "dbo.UserInformations");
            DropIndex("dbo.Results", new[] { "LoserId" });
            DropIndex("dbo.Results", new[] { "WinnerId" });
        }
    }
}
