namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "DonationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "DonationId", c => c.Int(nullable: false));
        }
    }
}
