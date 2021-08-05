using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class InvoiceDTOs
    {
        public Guid InvoiceID { get; set; }
        [StringLength(50, ErrorMessage = "Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Created Time is required")]
        public TimeSpan CreatedTime { get; set; }
        [Required(ErrorMessage = "Sub Total is required")]
        public bool Status { get; set; }
    }
}