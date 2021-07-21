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
        [Required(ErrorMessage = "User Type is required")]

        [StringLength(95, ErrorMessage = "User Type Should be between 3 to 9", MinimumLength = 3)]
        public string Type { get; set; }
    }
}
