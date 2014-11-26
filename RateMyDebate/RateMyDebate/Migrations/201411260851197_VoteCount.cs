namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoteCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "WinnerVotesCount", c => c.Int());
            AddColumn("dbo.Results", "LoserVotesCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "LoserVotesCount");
            DropColumn("dbo.Results", "WinnerVotesCount");
        }
    }
}
