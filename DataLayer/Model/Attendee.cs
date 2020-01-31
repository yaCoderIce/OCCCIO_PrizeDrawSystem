using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrizeDraw.DataLayer.Model
{
    /// <summary>
    /// Attendee Class
    /// use to generate attendee
    /// @see Attendees table
    /// </summary>
    public class Attendee
    {

        public int Id { get; set; }

        [Display(Name="First Name")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        /* Phone validation seems pretty broken. Can't validate length? 
         * Everyone seems to just be useing their own formats anyway so
         * just accept it.
        */
        //[Phone] 
        [StringLength(50)]
        public string MobilePhone { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(2)]
        public string Province { get; set; }

        [StringLength(6)]
        public string PostalCode { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        public bool IsCheckedIn { get; set; }

        public DateTime? CheckedInTime { get; set; }

        public IList<Scan> Scans { get; set; }
        
    }
}
