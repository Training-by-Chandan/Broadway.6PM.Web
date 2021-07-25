namespace Broadway._6PM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredFieldApplied : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vendors", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Vendors", "MobileNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Vendors", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "Email", c => c.String());
            AlterColumn("dbo.Vendors", "MobileNumber", c => c.String());
            AlterColumn("dbo.Vendors", "Address", c => c.String());
            AlterColumn("dbo.Vendors", "Name", c => c.String());
        }
    }
}
