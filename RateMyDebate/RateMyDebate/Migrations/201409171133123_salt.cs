namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "Salt");
        }
    }
}
