namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "DonationId", c => c.Int(nullable: false));
            DropColumn("dbo.ProjectCategories", "DonationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectCategories", "DonationId", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "DonationId");
        }
    }
}
