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
    public class BookingController : Controller
    {
        private readonly BookingService bookingService = new BookingService();
        public ActionResult Index()
        {
            var bookings = bookingService.GetAll();
            return View(bookings);
        }

        public ActionResult Create()
        {
            BookingDTOs model = new BookingDTOs();
            bookingService.CreateSelectList(model);           
            bookingService.CreateSelectListTable(model);           
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookingDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = bookingService.Create(model);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }

            }
            bookingService.CreateSelectList(model);
            bookingService.CreateSelectListTable(model);

            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            BookingDTOs model = bookingService.GetById(id);
            bookingService.CreateSelectList(model);
            bookingService.CreateSelectListTable(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookingDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = bookingService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            bookingService.CreateSelectList(model);
            bookingService.CreateSelectListTable(model);
            return View(model);
        }

        public ActionResult Details(Guid Id)
        {
            BookingDTOs model = bookingService.GetById(Id);
            return View(model);
        }

        public ActionResult Delete(Guid Id)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                var model = db.Bookings.Find(Id);
                db.Bookings.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}