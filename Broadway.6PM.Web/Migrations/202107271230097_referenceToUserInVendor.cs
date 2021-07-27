namespace Broadway._6PM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class referenceToUserInVendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vendors", "UserId");
            AddForeignKey("dbo.Vendors", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Vendors", new[] { "UserId" });
            DropColumn("dbo.Vendors", "UserId");
        }
    }
}
