using Microsoft.AspNetCore.Mvc.Rendering;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Model.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class UserCreateEditViewModel
    {
        [Required]
        [StringLength(25)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name ="Linked Vendor")]
        public int? VendorId { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string PasswordValidate { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public IList<string> Roles { get; set; }

        public IList<SelectListItem> RolesListItems { get; set; }

        public IList<SelectListItem> VendorListItems { get; set; }

        public void FillVendorsList(IList<Vendor> vendors)
        {
            VendorListItems = new List<SelectListItem>();

            foreach (Vendor vendor in vendors)
            {
                ((List<SelectListItem>)VendorListItems).Add(new SelectListItem()
                {
                    Text = vendor.Name,
                    Value = vendor.Id.ToString()
                });
            }
        }

        public void FillRolesList(IList<Role> roles)
        {
            RolesListItems = new List<SelectListItem>();

            foreach (Role role in roles)
            {
                ((List<SelectListItem>)RolesListItems).Add(new SelectListItem()
                {
                    Text = role.Name,
                    /* The identity system likes to use role names rather than Ids, so just play along */
                    Value = role.Name
                });
            }
        }
    }
}
