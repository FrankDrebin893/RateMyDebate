namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testuserlistremove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInformations", "Debate_DebateId", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "Debate_DebateId1", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "Debate_DebateId2", "dbo.Debates");
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId1" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId2" });
            DropColumn("dbo.UserInformations", "Debate_DebateId");
            DropColumn("dbo.UserInformations", "Debate_DebateId1");
            DropColumn("dbo.UserInformations", "Debate_DebateId2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInformations", "Debate_DebateId2", c => c.Int());
            AddColumn("dbo.UserInformations", "Debate_DebateId1", c => c.Int());
            AddColumn("dbo.UserInformations", "Debate_DebateId", c => c.Int());
            CreateIndex("dbo.UserInformations", "Debate_DebateId2");
            CreateIndex("dbo.UserInformations", "Debate_DebateId1");
            CreateIndex("dbo.UserInformations", "Debate_DebateId");
            AddForeignKey("dbo.UserInformations", "Debate_DebateId2", "dbo.Debates", "DebateId");
            AddForeignKey("dbo.UserInformations", "Debate_DebateId1", "dbo.Debates", "DebateId");
            AddForeignKey("dbo.UserInformations", "Debate_DebateId", "dbo.Debates", "DebateId");
        }
    }
}
