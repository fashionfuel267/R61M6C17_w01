namespace R61M6C17_w01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "ProductId" });
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        ItemName = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesDate = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesOrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemName = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SalesOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Purchases", "Total", c => c.Double(nullable: false));
            DropColumn("dbo.Purchases", "ProductId");
            DropColumn("dbo.Purchases", "Qty");
            DropTable("dbo.Sales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Purchases", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SalesOrderDetails", "OrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseID", "dbo.Purchases");
            DropIndex("dbo.SalesOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseID" });
            DropColumn("dbo.Purchases", "Total");
            DropTable("dbo.SalesOrderDetails");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.PurchaseDetails");
            CreateIndex("dbo.Sales", "ProductId");
            CreateIndex("dbo.Purchases", "ProductId");
            AddForeignKey("dbo.Sales", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
