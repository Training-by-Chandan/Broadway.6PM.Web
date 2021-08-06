namespace Broadway._6PM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageresource : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageResources", "ProductId", "dbo.Products");
            DropIndex("dbo.ImageResources", new[] { "ProductId" });
            DropTable("dbo.ImageResources");
        }
    }
}
