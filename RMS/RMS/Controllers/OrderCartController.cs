using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DatabaseLayer;

namespace RMS.Controllers
{
    public class OrderCartController : Controller
    {

        private ResturantManagementDBEntities DB = new ResturantManagementDBEntities();

        private List<CartDTOs> ListofCart;


        public OrderCartController()
        {
            DB = new ResturantManagementDBEntities();
            ListofCart = new List<CartDTOs>();
        }

        //GET: OrderCart
        public ActionResult Index()
        {
            IEnumerable<OrderCartDTOs> ListofOrderCarts = (from DBMenu in DB.Menus
                                                           join
                                                           DBSubCategory in DB.DishSubCategories
                                                           on DBMenu.SubCategoryID equals DBSubCategory.SubCategoryID
                                                           select new OrderCartDTOs()
                                                           {
                                                               MenuID = DBMenu.MenuID,
                                                               MenuName = DBMenu.MenuName,
                                                               MenuPrice = DBMenu.MenuPrice,
                                                               ImagePath = DBMenu.ImagePath,
                                                               SubCategory = DBSubCategory.SubCategoryName

                                                           }).ToList();
            return View(ListofOrderCarts);
        }


        [HttpPost]
        public JsonResult Index(Guid MenuId)
        {
            ViewBag.CustomerID = new SelectList(DB.CustomerNames.ToList(), "CustomerID", "CustomerName");
            ViewBag.TableID = new SelectList(DB.TableNames.ToList(), "TableID", "TableName");
            CartDTOs dTOs = new CartDTOs();
            Menu menu = DB.Menus.Single(model => model.MenuID == MenuId);
            if (Session["CartCounter"] != null)
            {
                ListofCart = Session["CartItem"] as List<CartDTOs>;
            }
            if (ListofCart.Any(model => model.MenuId == MenuId))
            {
                dTOs = ListofCart.Single(model => model.MenuId == MenuId);
                
                dTOs.Quantity++;
                dTOs.Total = dTOs.Quantity * dTOs.UnitPrice;
            }
            else
            {
                dTOs.MenuId = MenuId;
                dTOs.MenuName = menu.MenuName;
                dTOs.ImagePath = menu.ImagePath;
                dTOs.Quantity = 1;
                dTOs.Total = Convert.ToDecimal(menu.MenuPrice);
                dTOs.UnitPrice = Convert.ToDecimal(menu.MenuPrice);
               
                
                ListofCart.Add(dTOs);

            }

            Session["CartCounter"] = ListofCart.Count;
            Session["CartItem"] = ListofCart;
            return Json(new { Success = true, Counter = ListofCart.Count }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult OrderCart()
        {
            ListofCart = Session["CartItem"] as List<CartDTOs>;
            OrderCartsDTOs ordercart = new OrderCartsDTOs();
            ordercart.Carts = ListofCart;
            ordercart.Total = ListofCart.Sum(x => x.Total);
            return View(ordercart);
        }

        [HttpPost]
        public ActionResult AddOrder(OrderCartsDTOs model)
        {

            int OrderCartId = 10;

            ListofCart = model.Carts;
            OrderCart orderCart = new OrderCart()
            {
                OrderDate = DateTime.Now,
                OrderNumber = String.Format("(0:ddmmyyyyhhmmss)", DateTime.Now),
                OrderStatus = false,
                OrderCartID = OrderCartId + 1, 


        };
           
                DB.OrderCarts.Add(orderCart);
            DB.SaveChanges();

            OrderCartId = orderCart.OrderCartID;
            foreach (var item in ListofCart)
            {
                CartDetail cartModel = new CartDetail();
                cartModel.Total = item.Total;
                
                cartModel.MenuID = item.MenuId;               
                cartModel.Quantity = item.Quantity;
                cartModel.Price = item.UnitPrice;




                    DB.CartDetails.Add(cartModel);
                DB.SaveChanges();


            }
            Session["CartItem"] = null;
            Session["CartCounter"] = null;
            return RedirectToAction("Index");
        }

    }

}