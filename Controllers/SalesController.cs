using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using R61M6C17_w01.Models;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace R61M6C17_w01.Controllers
{
    [EnableCors("*","*","*")]
    public class SalesController : ApiController
    {
        private readonly InventoryContext db=new InventoryContext();
        //public IHttpActionResult Post(SalesOrder salesOrder)
        //{
        //    try
        //    {

        //        SalesOrder objsal = new SalesOrder();
        //        objsal.CustomerName = salesOrder.CustomerName;
        //        //objsal.Address = salesOrder.Address;
        //        objsal.OrderNumber = salesOrder.OrderNumber;
        //        objsal.SalesDate = salesOrder.SalesDate;
        //        db.SalesOrder.Add(salesOrder);
        //        int x = db.SaveChanges();

                
        //        return Json( new { Success = true, Message = "Data Successfully Added" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json( new { Success = false, Message = ex.Message });
        //    }

        //}

       
        public IHttpActionResult Post(SalesOrder salesOrder)
        {
            //int stockQty = db.Stocks.Where(s => s.PoductId == purchase.ProductId).Select(s => s.StockQty).FirstOrDefault();
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    SalesOrder objsal = new SalesOrder();
                    objsal.CustomerName = salesOrder.CustomerName;
                    //objsal.Address = salesOrder.Address;
                    objsal.OrderNumber = salesOrder.OrderNumber;
                    objsal.SalesDate = salesOrder.SalesDate;
                    db.SalesOrder.Add(salesOrder);
                    int x = db.SaveChanges();

                    foreach(var item in salesOrder.SalesOrderDetails)
                    {
                        var stocktoUpdate = db.Stocks.FirstOrDefault(p => p.Id == item.ProductId);
                        if (stocktoUpdate != null)
                        {
                           // var stocktoUpdate = db.Stocks.FirstOrDefault(p => p.Id == item.ProductId);
                            stocktoUpdate.StockQty = stocktoUpdate.StockQty + item.Quantity;
                            db.Entry(stocktoUpdate).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            var stocktoInsert = new Stock
                            {
                                PoductId = item.ProductId,
                                StockQty = item.Quantity,
                                StockPrice = (db.Products.FirstOrDefault(p => p.Id == item.ProductId).Price) * item.Quantity
                            };
                            db.Stocks.Add(stocktoInsert);
                          
                        }
                      x=  db.SaveChanges();

                    }            

                    if (x > 0)
                    {
                        dbTransaction.Commit();
                        return Ok(salesOrder);
                    }
                    else
                    {
                        dbTransaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    return BadRequest(ex.Message);
                }
                finally
                {

                }
            }
            return BadRequest("Save failed");

        }


    }
}
