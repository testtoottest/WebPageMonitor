namespace WebPageMonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeInterval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageUserMappings", "TimeIntervalInSeconds", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageUserMappings", "TimeIntervalInSeconds");
        }
    }
}
