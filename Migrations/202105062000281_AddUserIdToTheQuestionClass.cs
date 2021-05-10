namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToTheQuestionClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "UserId_Id", newName: "UserId");
            RenameIndex(table: "dbo.Questions", name: "IX_UserId_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Questions", name: "IX_UserId", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.Questions", name: "UserId", newName: "UserId_Id");
        }
    }
}
