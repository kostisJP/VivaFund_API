namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUrlField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Url");
        }
    }
}
