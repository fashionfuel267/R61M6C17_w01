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
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
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
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public string VendorName { get; set; }
        public virtual Product Product { get; set; }
    }
    public class Sales
    {
        public int Id { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yy}", 
            ApplyFormatInEditMode = true)]
        public DateTime SalesDate { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public string CustomerName { get; set; }

        public virtual Product Product { get; set; }
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