namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswersRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Answers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "Content", c => c.String());
        }
    }
}
