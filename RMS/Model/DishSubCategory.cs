using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class DishSubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }
        [Required(ErrorMessage = "Sub Category Name is required")]
        public string SubCategoryName { get; set; }
        public int DishCategoryID { get; set; }
    }
}