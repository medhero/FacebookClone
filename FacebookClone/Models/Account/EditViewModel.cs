using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace FacebookClone.Models.Account
{
    public class EditViewModel
    {
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }





    }
}