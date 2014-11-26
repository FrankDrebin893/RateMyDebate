namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoteCount2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "CreatorVotesCount", c => c.Int());
            AddColumn("dbo.Results", "ChallengerVotesCount", c => c.Int());
            DropColumn("dbo.Results", "WinnerVotesCount");
            DropColumn("dbo.Results", "LoserVotesCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "LoserVotesCount", c => c.Int());
            AddColumn("dbo.Results", "WinnerVotesCount", c => c.Int());
            DropColumn("dbo.Results", "ChallengerVotesCount");
            DropColumn("dbo.Results", "CreatorVotesCount");
        }
    }
}
