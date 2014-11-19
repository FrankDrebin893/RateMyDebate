namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Results : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        DebateId = c.Int(nullable: false),
                        WinnerId = c.Int(nullable: false),
                        LoserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DebateId)
                .ForeignKey("dbo.Debates", t => t.DebateId)
                .Index(t => t.DebateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "DebateId", "dbo.Debates");
            DropIndex("dbo.Results", new[] { "DebateId" });
            DropTable("dbo.Results");
        }
    }
}
