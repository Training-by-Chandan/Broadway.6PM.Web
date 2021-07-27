using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.ViewModel.Admin
{
    public class VendorsCreateRequestViewModel : RequestViewModel
    {
        [Required(ErrorMessage = "Name of the vendor is required")]
        [Display(Name = "Name of Vendors")]
        [StringLength(50, ErrorMessage = "Name exceeded more than 50 Characters")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNUmber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }

    public class VendorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string MobileNUmber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public DateTime StartDate { get; set; }
    }

    public class VendorsCreateResponseViewModel : ResponseViewModel
    {
    }
}