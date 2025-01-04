namespace R61M6C17_w01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesOrderDetails", "ProductId", c => c.Int(nullable: true));
            AlterColumn("dbo.SalesOrderDetails", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesOrderDetails", "ProductId");
            AddForeignKey("dbo.SalesOrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.SalesOrderDetails", "ItemName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesOrderDetails", "ItemName", c => c.String());
            DropForeignKey("dbo.SalesOrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesOrderDetails", new[] { "ProductId" });
            AlterColumn("dbo.SalesOrderDetails", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SalesOrderDetails", "ProductId");
        }
    }
}
