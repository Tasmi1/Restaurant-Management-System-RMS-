using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class KitchineOrderService
    {
        private readonly KitchineOrderConverter converter = new KitchineOrderConverter();
        private readonly OrderDetailsConverter orderDetailsConverter = new OrderDetailsConverter();
        private OrderDetailsDTOs orderItems;

        public List<KitchineOrderDTOs> GetAll()
        {
            List<KitchineOrderDTOs> orders = new List<KitchineOrderDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                                     
                    var orderdate = db.OrderCarts.Where(x => x.OrderDate == DateTime.Today & x.OrderStatus == false).ToList();
                    foreach (var order in orderdate)
                    {
                        {
                            orders.Add(converter.ConvertToModel(order));

                        }
                    }
                    return orders;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        //public OrderDetailsDTOs GetById(int orderCartID)
        //{
        //    OrderDetailsDTOs model = new OrderDetailsDTOs();
        //    try
        //    {
        //        using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
        //        {
        //            IEnumerable<OrderDetailsDTOs> orderItems = (from o in db.OrderCarts
        //                                                        join oI in db.CartDetails on o.OrderCartID equals oI.OrderCartID
        //                                                        join me in db.Menus on oI.MenuID equals me.MenuID
        //                                                        where o.OrderCartID == orderCartID
        //                                                        select new OrderDetailsDTOs()
        //                                                        {
        //                                                            OrderCartID = o.OrderCartID,
        //                                                            OrderDate = o.OrderDate,
        //                                                            CustomerName = oI.Customer.CustomerName,
        //                                                            Quantity = oI.Quantity,
        //                                                            MenuName = me.MenuName

        //                                                        }
        //                ).ToList();

        //            orderItems = (IEnumerable<OrderDetailsDTOs>)model;

        //            return model;
        //        }
               
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
    }
}