namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompositeVoteKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Votes");
            AddPrimaryKey("dbo.Votes", new[] { "VoterId", "DebateId" });
            DropColumn("dbo.Votes", "VoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "VoteId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Votes");
            AddPrimaryKey("dbo.Votes", "VoteId");
        }
    }
}
