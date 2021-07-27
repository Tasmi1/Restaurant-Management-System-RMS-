using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class DishCategory
    {
        [Key]
        public int DishCategoryID { get; set; }
        [Required(ErrorMessage = "Dish Category Name is required")]
        public string DishCategoryName { get; set; }
    }
}