using DatabaseLayer;
using RMS.Model.Services;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace RMS.Controllers
{

    public class OrderController: Controller
    {
        private ResturantManagementDBEntities db = new ResturantManagementDBEntities();

        public readonly OrderService orderService = new OrderService();
        public ActionResult Index()
        {
            var orders = orderService.GetAll();
            return View(orders);
        }
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers.ToList(), "CustomerID", "CustomerName");
            var menus = db.Menus.ToList().Select(m => new DropDownOrder { Id = m.MenuID, Name = m.MenuName, Price = m.MenuPrice }).ToList();
            List<OrderItems> orderItems = new List<OrderItems>() { new OrderItems { Quantity = 0, SubTotal = 0, MenuID = db.Menus.FirstOrDefault().MenuID } };
            OrderDTOs orderDTOs = new OrderDTOs
            {
                DDItems = menus,
                OrderItems = orderItems
            };

            orderService.CreateSelectList(orderDTOs);
            return View(orderDTOs);

        }
        [HttpPost]
        public ActionResult Create(OrderDTOs model)
        {
            ViewBag.CustomerId = new SelectList(db.Customers.ToList(), "CustomerID", "CustomerName", model.CustomerID);
            var order = db.InventoryProducts.ToList().Select(m => new DropDownOrder { Id = m.InventoryProductID, Name = m.ProductsName }).ToList();

            model.DDItems = order;

            if(ModelState.IsValid)
            {
                Order order2 = new Order
                {
                    OrderTime = TimeSpan.Zero,
                    OrderDate = DateTime.Now,
                    CustomerID = model.CustomerID,
                    MenuID = model.MenuID,
                    
                   

                };
                db.Orders.Add(order2);
                db.SaveChanges();

                Customer customer = db.Customers.FirstOrDefault(m => m.CustomerID == model.CustomerID);
                db.SaveChanges();

                foreach(var items in model.OrderItems)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        OrderID = order2.OrderID,
                        Price = items.Price,
                        Quantity = items.Quantity
                       /* SubTotal = items.SubTotal*/
                    };
                    db.OrderItems.Add(orderItem);
                    db.SaveChanges();

                    InventoryProduct inventoryProduct = db.InventoryProducts.FirstOrDefault(m => m.InventoryProductID == items.Id);
                    db.SaveChanges();
                }

                orderService.CreateSelectList(model);
                return RedirectToAction("Index");

                               

            }
            else
            {
                return View(model);
            }


        }

        public ActionResult Edit(Guid id)
        {
            OrderDTOs model = orderService.GetById(id);
            orderService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(OrderDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = orderService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        /*public ActionResult Details(Guid id)
        {
            OrderDTOs model = orderService.GetById(id);
            return View(model);
        }
*/

      
        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Orders.Find(id);
                db.Orders.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}