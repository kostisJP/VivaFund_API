namespace VivaFund.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "AuthenticationType", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "UserID");
            AddForeignKey("dbo.Members", "UserID", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Members", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Email", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Members", "UserID", "dbo.Users");
            DropIndex("dbo.Members", new[] { "UserID" });
            DropColumn("dbo.Users", "AuthenticationType");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Members", "UserID");
        }
    }
}
