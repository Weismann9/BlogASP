namespace BlogASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Created_at", c => c.String());
            AlterColumn("dbo.Posts", "Updated_at", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Updated_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "Created_at", c => c.DateTime(nullable: false));
        }
    }
}
