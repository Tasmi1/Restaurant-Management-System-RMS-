using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }
        //[Required(ErrorMessage = "User Tyoe is required")]
        //public int UserType { get; set; }
    }
}
