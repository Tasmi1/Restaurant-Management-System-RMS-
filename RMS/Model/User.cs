
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
        public int FName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public int LName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
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