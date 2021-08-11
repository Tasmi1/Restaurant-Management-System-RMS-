using DatabaseLayer;
using RMS.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class KitchineOrderController : Controller
    {
        private readonly KitchineOrderService orderService = new KitchineOrderService();
        // GET: KitchineOrder
        public ActionResult Index()
        {
            var order = orderService.GetAll();
            return View(order);
        }
        //        SELECT* FROM CartDetails
        //INNER JOIN OrderCart o ON o.OrderCartID = CartDetails.OrderCartID
        //INNER JOIN Menu m ON CartDetails.MenuID = m.MenuID;


        public ActionResult OrderDetails()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                List<OrderCart> order = db.OrderCarts.ToList();
                List<CartDetail> orderItems = db.CartDetails.ToList();
                List<Menu> menus = db.Menus.ToList();

                var employeeRecord = from o in order
                                     join d in orderItems on e.Department_Id equals d.DepartmentId into table1
                                     from d in table1.ToList()
                                     join i in incentives on e.Incentive_Id equals i.IncentiveId into table2
                                     from i in table2.ToList()
                                     select new ViewModel
                                     {
                                         employee = e,
                                         department = d,
                                         incentive = i
                                     };
                return View(employeeRecord);
            }
        }
    }
}