namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInformations", "userId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInformations", "userId");
        }
    }
}
