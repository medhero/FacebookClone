namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
