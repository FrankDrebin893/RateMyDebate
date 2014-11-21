namespace RateMyDebate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friendship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        FriendshipId = c.Int(nullable: false, identity: true),
                        FriendOneId = c.Int(nullable: false),
                        FriendTwoId = c.Int(nullable: false),
                        Since = c.DateTime(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FriendshipId)
                .ForeignKey("dbo.UserInformations", t => t.FriendOneId)
                .ForeignKey("dbo.UserInformations", t => t.FriendTwoId)
                .Index(t => t.FriendOneId)
                .Index(t => t.FriendTwoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "FriendTwoId", "dbo.UserInformations");
            DropForeignKey("dbo.Friendships", "FriendOneId", "dbo.UserInformations");
            DropIndex("dbo.Friendships", new[] { "FriendTwoId" });
            DropIndex("dbo.Friendships", new[] { "FriendOneId" });
            DropTable("dbo.Friendships");
        }
    }
}
