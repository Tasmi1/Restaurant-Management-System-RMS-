using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class OrderItems
    {
        [Key]
        public int ItemID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}