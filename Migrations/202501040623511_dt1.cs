namespace R61M6C17_w01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "PurchaseNumber", c => c.String());
            AddColumn("dbo.SalesOrders", "OrderNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesOrders", "OrderNumber");
            DropColumn("dbo.Purchases", "PurchaseNumber");
        }
    }
}
