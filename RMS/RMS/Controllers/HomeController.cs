using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                 ViewBag.countUser = db.Users.Count();
                 ViewBag.countCustomer = db.Customers.Count();
                 ViewBag.totalOrder = db.Orders.Count();
                 ViewBag.Date = db.Orders.Where(x => x.OrderDate == DateTime.Today).Count();

                return View();
                
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}