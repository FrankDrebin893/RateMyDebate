namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebateTimeLimitProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Debates", "TimeLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Debates", "TimeLimit");
        }
    }
}
