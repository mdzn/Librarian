using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Librarian.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string FName { get; set; }

        [Display(Name = "Last name")]
        public DateTime LName { get; set; }

        public string Sex { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DOB { get; set; }

        // Add the Address Info:
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}