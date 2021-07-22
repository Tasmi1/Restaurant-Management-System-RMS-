using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class MenuDTOs
    {
        //public MenuDTOs()
        //{
        //    SubCategory = new List<BaseGuidSelect>();
        //}
        public Guid MenuID { get; set; }
        [StringLength(50, ErrorMessage = "Menu Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Menu Name is required")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "Menu Price is required")]
        [StringLength(50, MinimumLength = 5)]

        public string MenuPrice { get; set; }
        public Guid SubCategoryID { get; set; }

        //public List<BaseGuidSelect> SubCategory { get; set; }

        //public string SubCategory { get; set; }
    }
}