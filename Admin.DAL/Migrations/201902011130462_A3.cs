namespace Admin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "SupCategoryId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SupProductId", c => c.Guid());
            AlterColumn("dbo.Products", "Barcode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Invoices", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Invoices", "Id2", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "Id2", c => c.Guid(nullable: false));
            AlterColumn("dbo.Invoices", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "Barcode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Products", "SupProductId", c => c.Guid());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "SupCategoryId", c => c.Int());
        }
    }
}
