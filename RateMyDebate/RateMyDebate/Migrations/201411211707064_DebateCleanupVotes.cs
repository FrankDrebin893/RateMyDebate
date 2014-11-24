namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebateCleanupVotes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Debates", "CreatorVotes");
            DropColumn("dbo.Debates", "ChallengerVotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Debates", "ChallengerVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Debates", "CreatorVotes", c => c.Int(nullable: false));
        }
    }
}
