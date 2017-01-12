namespace WebPageMonitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeInfoes",
                c => new
                    {
                        ChangeInfoId = c.Int(nullable: false, identity: true),
                        ChangeId = c.Int(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ChangeInfoId)
                .ForeignKey("dbo.Changes", t => t.ChangeId, cascadeDelete: true)
                .Index(t => t.ChangeId);
            
            CreateTable(
                "dbo.Changes",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChangeId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Opinions",
                c => new
                    {
                        OpinionId = c.Int(nullable: false, identity: true),
                        ChangeId = c.Int(nullable: false),
                        PageUserMappingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpinionId)
                .ForeignKey("dbo.PageUserMappings", t => t.PageUserMappingId, cascadeDelete: true)
                .ForeignKey("dbo.Changes", t => t.ChangeId, cascadeDelete: true)
                .Index(t => t.ChangeId)
                .Index(t => t.PageUserMappingId);
            
            CreateTable(
                "dbo.PageUserMappings",
                c => new
                    {
                        PageUserMappingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageUserMappingId)
                .ForeignKey("dbo.Pages", t => t.PageId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        PageUserMappingId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.RateId)
                .ForeignKey("dbo.PageUserMappings", t => t.PageUserMappingId, cascadeDelete: true)
                .Index(t => t.PageUserMappingId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        MailAddress = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MailAddress)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneNumber = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumber)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Opinions", "ChangeId", "dbo.Changes");
            DropForeignKey("dbo.Phones", "UserId", "dbo.Users");
            DropForeignKey("dbo.PageUserMappings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Mails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rates", "PageUserMappingId", "dbo.PageUserMappings");
            DropForeignKey("dbo.PageUserMappings", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Changes", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Opinions", "PageUserMappingId", "dbo.PageUserMappings");
            DropForeignKey("dbo.ChangeInfoes", "ChangeId", "dbo.Changes");
            DropIndex("dbo.Phones", new[] { "UserId" });
            DropIndex("dbo.Mails", new[] { "UserId" });
            DropIndex("dbo.Rates", new[] { "PageUserMappingId" });
            DropIndex("dbo.PageUserMappings", new[] { "PageId" });
            DropIndex("dbo.PageUserMappings", new[] { "UserId" });
            DropIndex("dbo.Opinions", new[] { "PageUserMappingId" });
            DropIndex("dbo.Opinions", new[] { "ChangeId" });
            DropIndex("dbo.Changes", new[] { "PageId" });
            DropIndex("dbo.ChangeInfoes", new[] { "ChangeId" });
            DropTable("dbo.Phones");
            DropTable("dbo.Mails");
            DropTable("dbo.Users");
            DropTable("dbo.Rates");
            DropTable("dbo.Pages");
            DropTable("dbo.PageUserMappings");
            DropTable("dbo.Opinions");
            DropTable("dbo.Changes");
            DropTable("dbo.ChangeInfoes");
        }
    }
}
