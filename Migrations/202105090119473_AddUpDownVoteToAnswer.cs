namespace StackOverFlowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpDownVoteToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "UpVote", c => c.Int());
            AddColumn("dbo.Answers", "DownVote", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "DownVote");
            DropColumn("dbo.Answers", "UpVote");
        }
    }
}
