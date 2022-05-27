namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Friend", name: "Sender_Id", newName: "SenderId");
            RenameColumn(table: "dbo.Friend", name: "UserId", newName: "RecieverID");
            RenameIndex(table: "dbo.Friend", name: "IX_UserId", newName: "IX_RecieverID");
            RenameIndex(table: "dbo.Friend", name: "IX_Sender_Id", newName: "IX_SenderId");
            DropPrimaryKey("dbo.Friend");
            AddPrimaryKey("dbo.Friend", "RequestId");
            DropColumn("dbo.Friend", "FriendId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Friend", "FriendId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Friend");
            AddPrimaryKey("dbo.Friend", "FriendId");
            RenameIndex(table: "dbo.Friend", name: "IX_SenderId", newName: "IX_Sender_Id");
            RenameIndex(table: "dbo.Friend", name: "IX_RecieverID", newName: "IX_UserId");
            RenameColumn(table: "dbo.Friend", name: "RecieverID", newName: "UserId");
            RenameColumn(table: "dbo.Friend", name: "SenderId", newName: "Sender_Id");
        }
    }
}
