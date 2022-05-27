namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "CommentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "CommentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "ID");
        }
    }
}
