namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainPageViewModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "User_Id", newName: "UserId_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_User_Id", newName: "IX_UserId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Questions", name: "IX_UserId_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Questions", name: "UserId_Id", newName: "User_Id");
        }
    }
}
