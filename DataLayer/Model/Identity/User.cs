using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrizeDraw.DataLayer.Model.Identity
{
    /// <summary>
    /// User Class
    /// used to generate new user
    /// @see Users table
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int? VendorId { get; set; }

        [Display(Name="Linked Vendor")]
        public Vendor Vendor { get; set; }

        [Display(Name="Roles")]
        public IList<UserRole> UserRoles { get; set; }
    }
}
