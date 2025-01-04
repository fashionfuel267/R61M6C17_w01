using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using R61M6C17_w01.Models;

namespace R61M6C17_w01.Controllers
{
    public class PurchaseController : ApiController
    {
        private readonly InventoryContext db=new InventoryContext();
        //[HttpPost]
        //public IHttpActionResult Post(Purchase purchase)
        //{
        //    //int stockQty = db.Stocks.Where(s => s.PoductId == purchase.ProductId).Select(s => s.StockQty).FirstOrDefault();
        //    using (var dbTransaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Stock stock = db.Stocks.Where(s => s.PoductId == purchase.ProductId).FirstOrDefault();
        //            Stock stock = db.Stocks.FirstOrDefault();
        //            db.Purchases.Add(purchase);
        //            if (stock == null)
        //            {
        //                var model = new Stock
        //                {
        //                    //PoductId = purchase.ProductId,
        //                    //StockQty=purchase.Qty,
        //                    //StockPrice= (db.Products.FirstOrDefault(p=>p.Id==purchase.ProductId).Price)*purchase.Qty
        //                    StockPrice = (db.Products.FirstOrDefault(p => p.Id == purchase.ProductId).Price) * purchase.Qty
        //                };
        //                db.Stocks.Add(model);
        //            }
        //            else
        //            {
        //                stock.StockQty = stock.StockQty + purchase.Qty;
        //                db.Entry(stock).State = System.Data.Entity.EntityState.Modified;
        //            }
                  
        //            if (db.SaveChanges() > 0)
        //            {
        //                dbTransaction.Commit();
        //                return Ok(purchase);
        //            }
        //            else
        //            {
        //                dbTransaction.Rollback();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest("Save failed");
        //        }
        //        finally
        //        {
                    
        //        }
        //    }
        //    return BadRequest("Save failed");

        //}
    }
}
