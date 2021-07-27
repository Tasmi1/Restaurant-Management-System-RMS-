using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Order TIme is required")]
        public DateTime OrderTime { get; set; }
        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Total is required")]
        public string Total { get; set; }
        public int CustomerID { get; set; }
        public int MenuID { get; set; }
    }
}