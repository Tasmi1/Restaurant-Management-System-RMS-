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
    public class DishSubCategoryController : Controller
    {

        private readonly DishSubCategoryService dishSubCategoryService = new DishSubCategoryService();
        // GET: DishSubCategory
        public ActionResult Index()
        {
            var dishSubCategories = dishSubCategoryService.GetAll();
            return View();
        }
        public ActionResult Create()
        {
            DishSubCategoryDTOs model = new DishSubCategoryDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DishSubCategoryDTOs dishsub)
        {
            if (ModelState.IsValid)
            {
                bool result = dishSubCategoryService.Create(dishsub);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(dishsub);
        }

        public ActionResult Details(Guid id)
        {
            DishSubCategoryDTOs model = dishSubCategoryService.GetById(id);
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var dishsub = db.UserTypes.Find(id);
                db.UserTypes.Remove(dishsub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}