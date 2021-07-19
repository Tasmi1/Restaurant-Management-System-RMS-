using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        [Required(ErrorMessage = "Menu Name is required")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "Menu Name is required")]
        public string MenuPrice { get; set; }
        public int DishCategoryID { get; set; }
    }
}