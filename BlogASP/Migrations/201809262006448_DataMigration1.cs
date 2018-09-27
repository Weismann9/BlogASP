namespace BlogASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "User_id_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_User_id_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_User_id_Id");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "User_id_Id");
        }
    }
}
