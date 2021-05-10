namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIsSelectedFromTags : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "IsSelected", c => c.Boolean());
        }
    }
}
