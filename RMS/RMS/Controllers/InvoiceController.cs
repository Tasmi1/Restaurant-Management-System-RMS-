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
    public class InvoiceController : Controller
    {
        private readonly InvoiceService invoiceService = new InvoiceService();
       
        public ActionResult Index()
        {
            var invoice = invoiceService.GetAll();
            return View(invoice);
        }
        public ActionResult Create()
        {
            InvoiceDTOs model = new InvoiceDTOs();
            invoiceService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(InvoiceDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = invoiceService.Create(model);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult Edit(Guid id)
        {
            InvoiceDTOs model = invoiceService.GetById(id);
            invoiceService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(InvoiceDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = invoiceService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            invoiceService.CreateSelectList(model);
            return View(model);
        }
        public ActionResult Details(Guid id)
        {
            InvoiceDTOs model = invoiceService.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Invoices.Find(id);
                db.Invoices.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}