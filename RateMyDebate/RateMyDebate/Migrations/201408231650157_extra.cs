namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Debates", "CreatorVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Debates", "ChallengerVotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Debates", "ChallengerVotes");
            DropColumn("dbo.Debates", "CreatorVotes");
        }
    }
}
