using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }
        [Required(ErrorMessage = "Vendor Name is required")]
        public string VendorName { get; set; }
        [Required(ErrorMessage = "Bill Nu,ber is required")]
        public string BillNumber { get; set; }
        [Required(ErrorMessage = "Total Price is required")]
        public string TotalPrice { get; set; }
        [Required(ErrorMessage = "Purchase Date is required")]
        public DateTime PurchaseDate { get; set; }


    }
}