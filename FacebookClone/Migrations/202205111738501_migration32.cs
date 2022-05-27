namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration32 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "FileExtension");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "FileExtension", c => c.String());
        }
    }
}
