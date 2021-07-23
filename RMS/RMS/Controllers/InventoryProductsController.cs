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
            var query = (from ip in db.InventoryProducts
                         join c in db.Categories on ip.CategoryID equals c.CategoryID
                         join pq in db.ProductQuantities on ip.ProductQuantityID equals pq.ProductQuantityID
                         select new
                         {
                             ip.InventoryProductID,
                             ip.ProductsName,
                             c.CategoryName,
                             pq.Quantity,
                             ip.ManufactureDate,
                             ip.ExpDate,
                             ip.Description
                             
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

        // GET: InventoryProducts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryProduct inventoryProduct = db.InventoryProducts.Find(id);
            if (inventoryProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", inventoryProduct.CategoryID);
            return View(inventoryProduct);
        }

        // POST: InventoryProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryProductID,ProductsName,ManufactureDate,ExpDate,Description,CategoryID")] InventoryProduct inventoryProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryProduct).State = EntityState.Modified;
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
