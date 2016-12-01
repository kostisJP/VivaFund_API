namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "RewardId", "dbo.Rewards");
            DropIndex("dbo.Donations", new[] { "RewardId" });
            AlterColumn("dbo.Donations", "RewardId", c => c.Int());
            CreateIndex("dbo.Donations", "RewardId");
            AddForeignKey("dbo.Donations", "RewardId", "dbo.Rewards", "RewardID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "RewardId", "dbo.Rewards");
            DropIndex("dbo.Donations", new[] { "RewardId" });
            AlterColumn("dbo.Donations", "RewardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Donations", "RewardId");
            AddForeignKey("dbo.Donations", "RewardId", "dbo.Rewards", "RewardID", cascadeDelete: true);
        }
    }
}
