using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class MenuDTOs
    {
        public Guid MenuID { get; set; }
        [Required(ErrorMessage = "Menu Name is required")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "Menu Price is required")]
        public string MenuPrice { get; set; }
        public Guid DishCategoryID { get; set; }
    }
}