using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class OrderConverter
    {
        public DatabaseLayer.Order ConvertToEntity(OrderDTOs model, DatabaseLayer.Order order)
        {
            order.OrderTime = model.OrderTime;
            order.OrderDate = model.OrderDate;
           
            //order.Menu.MenuName = model.MenuName;
         
            return order;
        }

        public OrderDTOs ConvertToModel(DatabaseLayer.Order model)
        {
            OrderDTOs order = new OrderDTOs();
            order.OrderID = model.OrderID;
            order.OrderTime = model.OrderTime;
            order.OrderDate = model.OrderDate;

            
            
            return order;
        }
    }
}