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
            ViewBag.VendorID = new SelectList(db.Vendors.ToList(), "VendorID","VendorName" );
            var products = db.InventoryProducts.ToList().Select(m => new DropDownOrder { Id = m.InventoryProductID, Name = m.ProductsName }).ToList();


            //NULL ERROR
            List<OrderItems> orderItems = new List<OrderItems>() { new OrderItems { Quantity = 0, SubTotal = 0, InventoryProductID = db.InventoryProducts.FirstOrDefault().InventoryProductID } };
            OrderDTOs orderDTOs = new OrderDTOs
            {
                DDItems = products,
                OrderItems = orderItems
            };

            orderService.CreateSelectList(orderDTOs);
            return View(orderDTOs);

        }
        [HttpPost]
        public ActionResult Create(OrderDTOs model)
        {
            ViewBag.VendorID = new SelectList(db.Vendors.ToList(), "VendorID", "VendorName", model.VendorID);
            var order = db.InventoryProducts.ToList().Select(m => new DropDownOrder { Id = m.InventoryProductID, Name = m.ProductsName }).ToList();
            model.DDItems = order;

            if(ModelState.IsValid)
            {
                double total = 0;
                Order ord = new Order
                {
                    OrderTime = model.OrderTime,
                    OrderDate = model.OrderDate,
                    VendorID = model.VendorID,
                    //InventoryProductID = model.InventoryProductID
                };
                var orderItems = new List<OrderItem>();
                foreach (var item in model.OrderItems)
                {
                    total += item.SubTotal;
                    orderItems.Add(new OrderItem
                    {
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ItemID = item.InventoryProductID
                    });
                }

                ord.Total = total.ToString();
                ord.OrderID = Guid.NewGuid();
                db.Orders.Add(ord);
                db.SaveChanges();

                ord.OrderItems = orderItems;
                foreach(var orderItem in orderItems)
                {
                    orderItem.OrderID = ord.OrderID;
                    orderItem.ItemID = Guid.NewGuid();
                    db.OrderItems.Add(orderItem);
                }
                db.SaveChanges();


//                Vendor vendor = db.Vendors.FirstOrDefault(m => m.VendorID == model.VendorID);
//                db.SaveChanges();

//                foreach(var items in model.OrderItems)
//                {
//                    OrderItem orderItem = new OrderItem
//                    {
//                        OrderID = order2.OrderID,
//                        Price = items.Price,
//                        Quantity = items.Quantity
//                       /* SubTotal = items.SubTotal*/
//                    };
//                    db.OrderItems.Add(orderItem);
//                    db.SaveChanges();


//                    InventoryProduct inventory = db.InventoryProducts.FirstOrDefault(m => m.InventoryProductID == items.InventoryProductID);
///*
//                    InventoryProduct inventoryProduct = db.InventoryProducts.FirstOrDefault(m => m.InventoryProductID == items.Id);*/

//                    db.SaveChanges();
               // }

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