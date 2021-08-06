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

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public string ImagePath { get; set; }

        public string MenuName { get; set; }

        public int OrderCartId { get; set; }

    }
}