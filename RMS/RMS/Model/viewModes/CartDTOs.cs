using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class CartDTOs
    {

        public Guid MenuId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }

        public string ImagePath { get; set; }

        public string MenuName { get; set; }

      

    }

    public class OrderCartsDTOs
    {
        public OrderCartsDTOs()
        {
            Carts = new List<CartDTOs>();
        }
        public decimal Total { get; set; }
        public List<CartDTOs> Carts { get; set; }
    }
}