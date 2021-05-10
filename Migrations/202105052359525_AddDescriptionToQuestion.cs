namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Description");
        }
    }
}
