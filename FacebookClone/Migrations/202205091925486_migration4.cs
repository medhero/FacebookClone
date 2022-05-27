namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", "CommentId");
            DropColumn("dbo.Comments", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", "ID");
        }
    }
}
