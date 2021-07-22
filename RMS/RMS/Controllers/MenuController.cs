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
    public class MenuController : Controller
    {
        private readonly MenuService menuServie = new MenuService();
        public ActionResult Index()
        {
            var menus = menuServie.GetAll();
            return View(menus);
        }

        public ActionResult Create()
        {

            MenuDTOs model = new MenuDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MenuDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = menuServie.Create(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            MenuDTOs model = menuServie.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MenuDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = menuServie.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
        public ActionResult Details(Guid id)
        {
            MenuDTOs model = menuServie.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Menus.Find(id);
                db.Menus.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}