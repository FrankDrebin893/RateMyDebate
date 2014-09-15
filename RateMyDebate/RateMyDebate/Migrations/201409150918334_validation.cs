namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInformations", "fName", c => c.String(nullable: false));
            AlterColumn("dbo.UserInformations", "lName", c => c.String(nullable: false));
            AlterColumn("dbo.UserInformations", "nickName", c => c.String(nullable: false));
            AlterColumn("dbo.UserInformations", "autobiography", c => c.String(nullable: false));
            AlterColumn("dbo.UserInformations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "userName", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserModels", "Password", c => c.String());
            AlterColumn("dbo.UserModels", "userName", c => c.String());
            AlterColumn("dbo.UserInformations", "Email", c => c.String());
            AlterColumn("dbo.UserInformations", "autobiography", c => c.String());
            AlterColumn("dbo.UserInformations", "nickName", c => c.String());
            AlterColumn("dbo.UserInformations", "lName", c => c.String());
            AlterColumn("dbo.UserInformations", "fName", c => c.String());
        }
    }
}
