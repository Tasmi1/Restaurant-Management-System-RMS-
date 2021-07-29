using DatabaseLayer;
using RMS.Model.Services;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class OrderController: Controller
    {
        public readonly OrderService orderService = new OrderService();
        public ActionResult Index()
        {
            var orders = orderService.GetAll();
            return View(orders);
        }
        public ActionResult Create()
        {
            OrderDTOs model = new OrderDTOs();
            orderService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(OrderDTOs model)
        {
           
            if (ModelState.IsValid)
            {
                bool result = orderService.Create(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult Edit(Guid id)
        {
            OrderDTOs model = orderService.GetById(id);
            orderService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(OrderDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = orderService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            OrderDTOs model = orderService.GetById(id);
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Orders.Find(id);
                db.Orders.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}