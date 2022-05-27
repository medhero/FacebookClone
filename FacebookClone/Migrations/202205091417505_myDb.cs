namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "ParentId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "ParentId" });
            AddColumn("dbo.Posts", "Post_like", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ParentId", c => c.Int());
            DropColumn("dbo.Posts", "Post_like");
            CreateIndex("dbo.Posts", "ParentId");
            AddForeignKey("dbo.Posts", "ParentId", "dbo.Posts", "PostId");
        }
    }
}
