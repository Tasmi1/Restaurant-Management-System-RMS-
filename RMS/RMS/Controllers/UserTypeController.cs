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
    public class UserTypeController : Controller
    {
        private readonly UserTypeService userTypeService = new UserTypeService();
        public ActionResult Index()
        {
            var userType = userTypeService.GetAll();
            return View(userType);
        }
        public ActionResult Create()
        {
            UserTypeDTOs model = new UserTypeDTOs();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserTypeDTOs model)
        {
            if (ModelState.IsValid)
            {
                if (!userTypeService.UserTypeValidation(model.Type))
                {
                    bool result = userTypeService.Create(model);
                    if (result == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("Type", "Duplicate User Type!");
                }
            }
            return View(model);
        }
        public ActionResult Edit(Guid id)
        {
            UserTypeDTOs model = userTypeService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserTypeDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = userTypeService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            UserTypeDTOs model = userTypeService.GetById(id);
            return View(model);
        }

       
        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.UserTypes.Find(id);
                db.UserTypes.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}