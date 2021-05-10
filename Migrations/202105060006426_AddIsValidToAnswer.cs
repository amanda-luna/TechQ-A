namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsValidToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "IsValid");
        }
    }
}
