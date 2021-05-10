namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSelectedToTagClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "IsSelected", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "IsSelected");
        }
    }
}
