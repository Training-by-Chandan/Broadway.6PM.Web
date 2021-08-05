namespace Broadway._6PM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "VendorId");
            AddForeignKey("dbo.Products", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            DropColumn("dbo.Products", "VendorId");
        }
    }
}
