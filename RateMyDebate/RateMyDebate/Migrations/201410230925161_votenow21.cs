namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class votenow21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        VoterId = c.Int(nullable: false),
                        DebateId = c.Int(nullable: false),
                        VotePos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.Debates", t => t.DebateId)
                .ForeignKey("dbo.UserInformations", t => t.VoterId)
                .Index(t => t.DebateId)
                .Index(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "VoterId", "dbo.UserInformations");
            DropForeignKey("dbo.Votes", "DebateId", "dbo.Debates");
            DropIndex("dbo.Votes", new[] { "VoterId" });
            DropIndex("dbo.Votes", new[] { "DebateId" });
            DropTable("dbo.Votes");
        }
    }
}
