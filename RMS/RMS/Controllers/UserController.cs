﻿using DatabaseLayer;
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
        public ActionResult Create(UserDTOs model)
        {
            if (ModelState.IsValid)
            {
                if (!userService.UserNameValidation(model.UserName))
                {
                    bool result = userService.Create(model);
                    if (result == true)
                    {

                        return RedirectToAction("Index");
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


        public void Logout()
        {
            Session["UserId"] = string.Empty;
            Session["FirstName"] = string.Empty;
            Session["LastName"] = string.Empty;
            Session["PhoneNumber"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            Session["Address"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["UserType"] = string.Empty;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string password, string email)
        {

            bool result = userService.Login( password, email);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Either Email or Password does't match";
            }

            if (result == false)
            {
                ViewBag.message = "Either Email or Password does't match";
            }

            return View();
        }
    }
}