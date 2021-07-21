
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public int FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public int LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [MinLength(10, ErrorMessage ="Number should be of 10 digits")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public int Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public int UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public int Password { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public int Address { get; set; }
        public int UserTypeID { get; set; }



    }
}