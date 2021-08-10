using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class InvoiceDTOs
    {
        public InvoiceDTOs()
        {
            CartDetails = new List<BaseIdSelect>();
        }

        public Guid InvoiceID { get; set; }
        [Required(ErrorMessage = "VAT is required")]
        public decimal VAT { get; set; }
        [Required(ErrorMessage = "Service Tax is required")]
        public decimal ServiceTax { get; set; }
        [Required(ErrorMessage = "Total is required")]
        public decimal ITotal { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool Status { get; set; }
        public int CartDetailID { get; set; }

        public List<BaseIdSelect> CartDetails { get; set; }

        public string CartDetail { get; set; }
    }
}