using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class KitchineOrderDTOs
    {
        public int OrderCartID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }      
        public bool OrderStatus { get; set; }


    }
}