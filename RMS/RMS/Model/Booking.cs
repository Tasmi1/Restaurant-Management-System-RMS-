using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public DateTime Date { get; set; }
        public string TableNumber { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int CustomerID { get; set; }

    }
}