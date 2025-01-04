using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R61M6C17_w01.Models
{
    public class InventoryContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }   
        public ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Category))]
        public int CatID { get; set; }
        public double Price { get; set; }
        public virtual Category Category { get; set; }

    }
    public class Purchase
    {
        public int Id { get; set; }
        [DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:dd-MM-yy}",
            ApplyFormatInEditMode =true)]
        public DateTime PurchaseDate { get; set; }
         
        public string PurchaseNumber { get; set; }
        public string VendorName { get; set; }
        public double Total { get; set; }
    public ICollection<PurchaseDetail> Details { get; set; }
    }
    public class PurchaseDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Purchase))]
        public int PurchaseID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public virtual Purchase Purchase { get; set; }
    }

    public class SalesOrder
    {
        public int Id { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yy}", 
            ApplyFormatInEditMode = true)]
        public DateTime SalesDate { get; set; }
         
         public string  OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }

        //public virtual Product Product { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
    public class SalesOrderDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(SalesOrder))]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }

    public class Stock
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int PoductId { get; set; }
        public int StockQty { get; set; }
        public double StockPrice { get; set; }
        public Product Product { get; set; }
    }
}