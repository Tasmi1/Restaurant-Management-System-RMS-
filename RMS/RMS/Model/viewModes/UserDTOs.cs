using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class UserDTOs
    {
        public int UserId { get; set; }
        [StringLength(50, ErrorMessage = "First Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "First Name is required")]
        public int FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Last Name Length should be between 3 to 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Last Name is required")]
        public int LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [MinLength(10, ErrorMessage = "Number should be of 10 digits")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public int Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, ErrorMessage = "User Length should be between 3 to 50", MinimumLength = 3)]
        public int UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public int Password { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, ErrorMessage = "Address Length should be between 3 to 50", MinimumLength = 3)]
        public int Address { get; set; }
        public int UserTypeID { get; set; }
    }
}