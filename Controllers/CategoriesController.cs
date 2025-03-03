﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Mvc;
using R61M6C17_w01.Models;


namespace R61M6C17_w01.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private readonly InventoryContext db=new InventoryContext();

        public CategoriesController() { }
        public IEnumerable<Category> Get()
        {
            return db.Categories;
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetParentCategory")]
        public IEnumerable<Category> GetParentCategory()
        {
            return db.Categories.Where(c=>c.ParentID==0);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ChildCategory")]
        public IEnumerable<Category> ChildCategory(int PId)
        {
            return db.Categories.Where(c => c.ParentID == PId);
        }
        public Category Get(int Id)
        {
            return db.Categories.Find(Id);
        }
        public void Post(Category category) { 
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void Put(Category category)
        {
            db.Entry(category).State= System.Data.Entity.EntityState.Modified;
           
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            db.Categories.Remove(db.Categories.Find(Id));
            db.SaveChanges();
        }
    }
}
