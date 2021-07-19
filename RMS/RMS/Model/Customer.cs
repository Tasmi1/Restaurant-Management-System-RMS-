using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}