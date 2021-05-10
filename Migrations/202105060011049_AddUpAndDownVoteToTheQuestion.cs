namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpAndDownVoteToTheQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "UpVote", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "DownVote", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "DownVote");
            DropColumn("dbo.Questions", "UpVote");
        }
    }
}
