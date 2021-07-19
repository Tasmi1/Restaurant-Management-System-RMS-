using RMS.Model.Services;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class CustomerController : Controller
    {
       private readonly CustomerService customerServie = new CustomerService();
        public ActionResult Index()
        {
            var customers = customerServie.GetAll();
            return View(customers);
        }

        public ActionResult Create()
        {
            CustomerDTOs model = new CustomerDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomerDTOs model)
        {
            if (ModelState.IsValid)
            {
              bool result =  customerServie.Create(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            CustomerDTOs model = customerServie.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = customerServie.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
    }
}