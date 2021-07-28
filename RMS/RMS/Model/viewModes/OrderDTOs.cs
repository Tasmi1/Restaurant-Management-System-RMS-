using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class OrderDTOs
    {
        public OrderDTOs()
        {
            Customers = new List<BaseGuidSelect>();
            Menus = new List<BaseGuidSelect>();
        }

        public Guid OrderID { get; set; }
        [Required(ErrorMessage = "Order Time is required")]
        public TimeSpan OrderTime { get; set; }
        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Total is required")]
        public string Total { get; set; }
        public Guid CustomerID { get; set; }
        public Guid MenuID { get; set; }

        public List<BaseGuidSelect> Customers { get; set; }
        public string CustomerName { get; set; }

        public List<BaseGuidSelect> Menus { get; set; }
        public string MenuName { get; set; }
    }
}