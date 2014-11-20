namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChallengerNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Debates", new[] { "ChallengerIdId" });
            AlterColumn("dbo.Debates", "ChallengerIdId", c => c.Int());
            CreateIndex("dbo.Debates", "ChallengerIdId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Debates", new[] { "ChallengerIdId" });
            AlterColumn("dbo.Debates", "ChallengerIdId", c => c.Int(nullable: false));
            CreateIndex("dbo.Debates", "ChallengerIdId");
        }
    }
}
