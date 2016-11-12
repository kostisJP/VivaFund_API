namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Token = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ProjectCategoryId = c.Int(nullable: false),
                        TitleEn = c.String(),
                        TitleEl = c.String(),
                        SubtitleEn = c.String(),
                        SubtitleEl = c.String(),
                        BodyEn = c.String(),
                        BodyEl = c.String(),
                        Goal = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectCategoryId);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ProjectCategoryId = c.Int(nullable: false, identity: true),
                        Token = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectCategoryId);
            
            CreateTable(
                "dbo.ProjectMedias",
                c => new
                    {
                        ProjectMediaId = c.Int(nullable: false, identity: true),
                        IsCoverImage = c.Boolean(nullable: false),
                        ProjectMediaType = c.Int(nullable: false),
                        URL = c.String(maxLength: 500),
                        ProjectId = c.Int(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectMediaId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Token = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectMedias", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories");
            DropForeignKey("dbo.Projects", "MemberId", "dbo.Members");
            DropIndex("dbo.ProjectMedias", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "ProjectCategoryId" });
            DropIndex("dbo.Projects", new[] { "MemberId" });
            DropTable("dbo.Users");
            DropTable("dbo.ProjectMedias");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.Projects");
            DropTable("dbo.Members");
        }
    }
}
