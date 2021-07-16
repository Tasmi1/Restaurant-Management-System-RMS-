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
