namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class receiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Receiver");
        }
    }
}
