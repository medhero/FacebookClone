namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friend",
                c => new
                    {
                        FriendId = c.String(nullable: false, maxLength: 128),
                        RequestId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FriendId)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.Sender_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friend", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friend", "Sender_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friend", new[] { "User_Id" });
            DropIndex("dbo.Friend", new[] { "Sender_Id" });
            DropIndex("dbo.Friend", new[] { "UserId" });
            DropTable("dbo.Friend");
        }
    }
}
