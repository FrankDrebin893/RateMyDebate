namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullDraw : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "Draw", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Results", "Draw", c => c.Boolean(nullable: false));
        }
    }
}
