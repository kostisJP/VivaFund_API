namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatebaseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Members", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Donations", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Rewards", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.ProjectCategories", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Filters", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.ProjectMedias", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.ProjectUpdates", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectUpdates", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectMedias", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Filters", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectCategories", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rewards", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Donations", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "UpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}
