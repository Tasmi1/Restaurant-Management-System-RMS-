using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderID { get; set; }
        public string VAT { get; set; }
        public string ServiceTAX { get; set; }
        [Required(ErrorMessage = "Total is required")]
        public string Total { get; set; }
    }
}