using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class BookingDTOs
    {
        public Guid BookingID { get; set; }
        public DateTime Date { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public Guid CustometID { get; set; }

    }


}