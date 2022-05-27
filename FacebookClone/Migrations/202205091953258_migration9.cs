namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration9 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddColumn("dbo.Comments", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Comments", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            DropColumn("dbo.Comments", "ID");
            AddPrimaryKey("dbo.Comments", "CommentId");
        }
    }
}
