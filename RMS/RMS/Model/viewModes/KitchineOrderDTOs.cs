using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class KitchineOrderDTOs
    {
        public int OrderCartID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }      
        public bool ? OrderStatus { get; set; }


    }
}