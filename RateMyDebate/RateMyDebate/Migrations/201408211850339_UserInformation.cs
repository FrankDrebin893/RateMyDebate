namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        userInformationId = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        lName = c.String(),
                        userName = c.String(),
                        age = c.Int(nullable: false),
                        autobiography = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.userInformationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInformations");
        }
    }
}
