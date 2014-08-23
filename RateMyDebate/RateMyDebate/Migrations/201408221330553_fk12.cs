namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debates",
                c => new
                    {
                        DebateId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        ChatText = c.String(),
                        CreatorId = c.Int(nullable: false),
                        ChallengerId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DebateId);
            
            AddColumn("dbo.UserInformations", "Debate_DebateId", c => c.Int());
            AddColumn("dbo.UserInformations", "Debate_DebateId1", c => c.Int());
            AddColumn("dbo.UserInformations", "Debate_DebateId2", c => c.Int());
            CreateIndex("dbo.UserInformations", "Debate_DebateId");
            CreateIndex("dbo.UserInformations", "Debate_DebateId1");
            CreateIndex("dbo.UserInformations", "Debate_DebateId2");
            AddForeignKey("dbo.UserInformations", "Debate_DebateId", "dbo.Debates", "DebateId");
            AddForeignKey("dbo.UserInformations", "Debate_DebateId1", "dbo.Debates", "DebateId");
            AddForeignKey("dbo.UserInformations", "Debate_DebateId2", "dbo.Debates", "DebateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInformations", "Debate_DebateId2", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "Debate_DebateId1", "dbo.Debates");
            DropForeignKey("dbo.UserInformations", "Debate_DebateId", "dbo.Debates");
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId2" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId1" });
            DropIndex("dbo.UserInformations", new[] { "Debate_DebateId" });
            DropColumn("dbo.UserInformations", "Debate_DebateId2");
            DropColumn("dbo.UserInformations", "Debate_DebateId1");
            DropColumn("dbo.UserInformations", "Debate_DebateId");
            DropTable("dbo.Debates");
        }
    }
}
