namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserModels", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "ConfirmPassword", c => c.String());
        }
    }
}
