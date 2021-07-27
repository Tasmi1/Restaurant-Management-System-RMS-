
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class InventoryProduct
    {
        [Key]
        public int InventoryProductID { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductsName { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpDate { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int CategoryID { get; set; }
    }
}