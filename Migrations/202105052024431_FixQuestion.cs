namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixQuestion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "UserId", c => c.Int(nullable: false));
        }
    }
}
