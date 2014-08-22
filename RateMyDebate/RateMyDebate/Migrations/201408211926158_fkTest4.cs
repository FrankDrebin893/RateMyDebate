namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkTest4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInformations", "nickName", c => c.String());
            DropColumn("dbo.UserInformations", "userName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInformations", "userName", c => c.String());
            DropColumn("dbo.UserInformations", "nickName");
        }
    }
}
