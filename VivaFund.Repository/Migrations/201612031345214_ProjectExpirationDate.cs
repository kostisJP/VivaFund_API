namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectExpirationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ExpirationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ExpirationDate");
        }
    }
}
