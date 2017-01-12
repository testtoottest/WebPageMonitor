namespace MonitorStron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.PersistedContents",
                c => new
                    {
                        PersistedContentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Content = c.String(),
                        AccessDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersistedContentId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersistedContents", "PageId", "dbo.Pages");
            DropIndex("dbo.PersistedContents", new[] { "PageId" });
            DropTable("dbo.PersistedContents");
            DropTable("dbo.Pages");
        }
    }
}
