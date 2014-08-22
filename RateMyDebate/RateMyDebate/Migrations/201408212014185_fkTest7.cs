namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        inboxId = c.Int(nullable: false, identity: true),
                        userInformationId_userInformationId = c.Int(),
                    })
                .PrimaryKey(t => t.inboxId)
                .ForeignKey("dbo.UserInformations", t => t.userInformationId_userInformationId)
                .Index(t => t.userInformationId_userInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inboxes", "userInformationId_userInformationId", "dbo.UserInformations");
            DropIndex("dbo.Inboxes", new[] { "userInformationId_userInformationId" });
            DropTable("dbo.Inboxes");
        }
    }
}
