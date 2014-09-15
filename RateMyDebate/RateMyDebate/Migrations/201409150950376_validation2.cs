namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "ConfirmPassword");
        }
    }
}
