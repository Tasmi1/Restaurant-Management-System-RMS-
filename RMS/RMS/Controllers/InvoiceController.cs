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
        private ResturantManagementDBEntities DB = new ResturantManagementDBEntities();

        public ActionResult Index()
        {
            //var invoice = invoiceService.GetAll();
            IEnumerable<OrderCartsDTOs> ListOfCartDetails = (IEnumerable<OrderCartsDTOs>)(from DBInvoice in DB.Invoices
                                                                                          join DBCartDetail in DB.CartDetails
                                                                                           on DBInvoice.CartDetailID equals DBCartDetail.CartDetailID
                                                                                          select new InvoiceDTOs()
                                                                                          {
                                                                                              CartDetailID = (int)Convert.ToDecimal(DBInvoice.InvoiceID),
                                                                                              ITotal = Convert.ToDecimal(DBInvoice.ITotal),
                                                                                              VAT = Convert.ToDecimal(DBInvoice.VAT),
                                                                                              ServiceTax = Convert.ToDecimal(DBInvoice.ServiceTax),
                                                                                              CartDetail =/* (int)*/Convert.ToString(DBCartDetail.Total),





                                                                                          }).ToList();

            return View(ListOfCartDetails);
        }

        //public ActionResult InvoiceDetail(int? cartDetailID)
        //{
        //    using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
        //    {
        //        IEnumerable<OrderCartsDTOs> cartDetails = (from i in db.Invoices
        //                                                  join cd in db.CartDetails on i.InvoiceID equals cd.CartDetailID
        //                                                  where i.InvoiceID == cartDetailID
        //                                                  select new OrderCartsDTOs()
        //                                                  {
        //                                                      CartDetailID = (int)Convert.ToDecimal(DBInvoice.InvoiceID),
        //                                                      ITotal = Convert.ToDecimal(DBInvoice.ITotal),
        //                                                      VAT = Convert.ToDecimal(DBInvoice.VAT),
        //                                                      ServiceTax = Convert.ToDecimal(DBInvoice.ServiceTax),
        //                                                      CartDetail =/* (int)*/Convert.ToString(DBCartDetail.Total),

        //                                                  }).ToList();








        //    }).ToList();




        //    return View(cartDetailID);
        //    }

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