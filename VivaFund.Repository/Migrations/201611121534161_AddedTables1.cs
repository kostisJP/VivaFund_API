namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        CommentBody = c.String(nullable: false, maxLength: 50),
                        CounterPlus = c.Int(nullable: false),
                        CounterMinus = c.Int(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        DonatedAmount = c.Int(nullable: false),
                        RewardId = c.Int(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DonationID)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Rewards", t => t.RewardId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ProjectId)
                .Index(t => t.RewardId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(),
                        Value = c.Int(nullable: false),
                        Title = c.String(),
                        RewardDescription = c.String(nullable: false, maxLength: 500),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RewardID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Filters",
                c => new
                    {
                        FilterId = c.Int(nullable: false, identity: true),
                        FilterType = c.Int(nullable: false),
                        FilterName = c.String(nullable: false, maxLength: 50),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FilterId);
            
            CreateTable(
                "dbo.ProjectUpdates",
                c => new
                    {
                        UpdateID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ProjectId = c.Int(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UpdateID)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectUpdates", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Donations", "RewardId", "dbo.Rewards");
            DropForeignKey("dbo.Rewards", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Donations", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Donations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropIndex("dbo.ProjectUpdates", new[] { "ProjectId" });
            DropIndex("dbo.Rewards", new[] { "ProjectID" });
            DropIndex("dbo.Donations", new[] { "RewardId" });
            DropIndex("dbo.Donations", new[] { "ProjectId" });
            DropIndex("dbo.Donations", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropIndex("dbo.Comments", new[] { "MemberId" });
            DropTable("dbo.ProjectUpdates");
            DropTable("dbo.Filters");
            DropTable("dbo.Rewards");
            DropTable("dbo.Donations");
            DropTable("dbo.Comments");
        }
    }
}
