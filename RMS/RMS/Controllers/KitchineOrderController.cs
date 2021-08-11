using RMS.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class KitchineOrderController : Controller
    {
        private readonly KitchineOrderService orderService = new KitchineOrderService();
        // GET: KitchineOrder
        public ActionResult Index()
        {
            var order = orderService.GetAll();
            return View(order);
        }
    }
}