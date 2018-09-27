namespace BlogASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "Updated_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Updated_at", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Created_at", c => c.Int(nullable: false));
        }
    }
}
