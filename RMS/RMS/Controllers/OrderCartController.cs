using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // GET: OrderCart
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
                                                              
                                                           }).ToList() ;
            return View(ListofOrderCarts);
        }

       
        [HttpPost]
        public JsonResult Index(Guid MenuId)
        {
            CartDTOs dTOs = new CartDTOs();
            Menu DBMenu = DB.Menus.Single(model => model.MenuID == MenuId);
            if(Session["CartCounter"] != null)
            {
                ListofCart = Session["CartItem"] as List<CartDTOs>;
            }
            if(ListofCart.Any(model => model.MenuId == MenuId))
            {
                dTOs = ListofCart.Single(model => model.MenuId == MenuId);
                dTOs.Quantity++;
                dTOs.Total = dTOs.Quantity * dTOs.Price;
            }
            else
            {
                dTOs.MenuId = MenuId;
                dTOs.MenuName = DBMenu.MenuName;
                dTOs.Quantity = 1;
                dTOs.Total = Convert.ToDecimal(DBMenu.MenuPrice);
                dTOs.Price = Convert.ToDecimal(DBMenu.MenuPrice);
                ListofCart.Add(dTOs);

            }
            Session["CartCounter"] = ListofCart.Count;
            Session["CartItem"] = ListofCart;
            return Json(new { Success = true, Counter = ListofCart.Count }, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult OrderCart()
        {
            ListofCart = Session["CartItem"] as List<CartDTOs>;
   
            return View(); 
        }

        [HttpPost]
        public ActionResult AddOrder()
        {
            //Guid OrderCartId = 0;
            ListofCart = Session["CartItem"] as List<CartDTOs>;
            OrderCart orderCart = new OrderCart()
            {
                OrderDate = DateTime.Now,
                OrderNumber = String.Format("(0:ddmmyyyyhhmmss)",DateTime.Now)

            };
            DB.OrderCarts.Add(orderCart);
            DB.SaveChanges();
            int orderCartId = orderCart.OrderCartID;
            foreach(var item in ListofCart)
            {
                CartDetail cartModel = new CartDetail
                {
                    Total = item.Total,
                    MenuID = item.MenuId,
                    OrderCartID = item.OrderCartId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                //CartDetail entitModel = new converter    
                    DB.CartDetails.Add(cartModel);
                DB.SaveChanges();
                    

            }
            Session["CartItem"] = null;
            Session["CartCounter"] = null;
            return RedirectToAction("Index");
        }

    }

}