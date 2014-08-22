namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        accountId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.accountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserModels");
        }
    }
}
