namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixQuestionNullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "UpVote", c => c.Int());
            AlterColumn("dbo.Questions", "DownVote", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "DownVote", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "UpVote", c => c.Int(nullable: false));
        }
    }
}
