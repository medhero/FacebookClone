namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "FilePath", c => c.String());
            DropColumn("dbo.Posts", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "FileName", c => c.String());
            DropColumn("dbo.Posts", "FilePath");
        }
    }
}
