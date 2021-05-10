namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionsRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Description", c => c.String());
            AlterColumn("dbo.Questions", "Title", c => c.String());
        }
    }
}
