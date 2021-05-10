namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIDtoAnswer : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Answers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Answers", "UserId");
            RenameColumn(table: "dbo.Answers", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Answers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Answers", new[] { "UserId" });
            AlterColumn("dbo.Answers", "UserId", c => c.String());
            RenameColumn(table: "dbo.Answers", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Answers", "UserId", c => c.String());
            CreateIndex("dbo.Answers", "ApplicationUser_Id");
        }
    }
}
