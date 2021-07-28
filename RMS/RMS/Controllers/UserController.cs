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
    public class UserController : Controller
    {
        private readonly UserService userService = new UserService();
        // GET: User
        public ActionResult Index()
        {
            var user = userService.GetAll();
            return View(user);
        }
        public ActionResult Create()
        {
            UserDTOs model = new UserDTOs();
            userService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserDTOs model, string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (!userService.UserNameValidation(model.UserName))
                {
                    bool result = userService.Create(model, ConfirmPassword);
                    if (result == true)
                    {

                        return RedirectToAction("Index");
                    }
                    if (result == false)
                    {
                        ViewBag.Message = "Your password and Confirm Password doesn't match";
                       
                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "Duplicate User Name!");
                }
               
            
            }
            userService.CreateSelectList(model);
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            UserDTOs model = userService.GetById(id);
            userService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = userService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            userService.CreateSelectList(model);
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            UserDTOs model = userService.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Users.Find(id);
                db.Users.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Register()
        {
            UserDTOs model = new UserDTOs();
            userService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(UserDTOs model, string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (!userService.UserNameValidation(model.UserName))
                {
                    bool result = userService.Create(model, ConfirmPassword);
                    if (result == true)
                    {

                        return RedirectToAction("Index");
                    }
                    if (result == false)
                    {
                        ViewBag.Message = "Your password and Confirm Password doesn't match";

                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "Duplicate User Name!");
                }


            }
            userService.CreateSelectList(model);
            return View(model);
        }

    }
}