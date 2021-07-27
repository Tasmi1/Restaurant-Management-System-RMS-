using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class PurchaseProduct
    {
        [Key]
        public int PurchaseProductID { get; set; }
        public int InventoryProductID { get; set; }
        public int VendorID { get; set; }
        [Required(ErrorMessage = "Quantity  is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }
    }

}