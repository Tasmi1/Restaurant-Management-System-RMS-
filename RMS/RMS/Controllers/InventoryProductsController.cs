using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer;

namespace RMS.Controllers
{
    public class InventoryProductsController : Controller
    {
        private ResturantManagementDBEntities db = new ResturantManagementDBEntities();

        // GET: InventoryProducts
        public ActionResult Index()
        {          
            var query = (from Ip in db.InventoryProducts
                         join C in db.Categories on Ip.CategoryID equals C.CategoryID
                         select new
                         {
                             Ip.InventoryProductID,
                             Ip.ProductsName,
                             C.CategoryName,
                             Ip.ManufactureDate,
                             Ip.ExpDate,
                             Ip.Description
                         });
            return View(query.ToList());
        }

        // GET: InventoryProducts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: InventoryProducts/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryProductID,ProductsName,ManufactureDate,ExpDate,Description,CategoryID")] InventoryProduct inventoryProduct)
        {
            if (ModelState.IsValid)
            {
                inventoryProduct.InventoryProductID = Guid.NewGuid();
                db.InventoryProducts.Add(inventoryProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", inventoryProduct.CategoryID);
            return View(inventoryProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
