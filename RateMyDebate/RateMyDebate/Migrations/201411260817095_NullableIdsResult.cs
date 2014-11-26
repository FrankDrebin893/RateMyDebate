namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableIdsResult : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Results", new[] { "WinnerId" });
            DropIndex("dbo.Results", new[] { "LoserId" });
            AlterColumn("dbo.Results", "WinnerId", c => c.Int());
            AlterColumn("dbo.Results", "LoserId", c => c.Int());
            CreateIndex("dbo.Results", "WinnerId");
            CreateIndex("dbo.Results", "LoserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Results", new[] { "LoserId" });
            DropIndex("dbo.Results", new[] { "WinnerId" });
            AlterColumn("dbo.Results", "LoserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Results", "WinnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Results", "LoserId");
            CreateIndex("dbo.Results", "WinnerId");
        }
    }
}
