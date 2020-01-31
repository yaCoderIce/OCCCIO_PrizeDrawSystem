using PrizeDraw.DataLayer.Model.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrizeDraw.DataLayer.Model
{ 
    /// <summary>
    /// Vendor Class
    /// Used to generate new vendor
    /// @see Vendors table
    /// </summary>
    public class Vendor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public IList<User> Users { get; set; }

        /// <summary>
        /// Sponsored Prizes
        /// </summary>
        public IList<Prize> Prizes { get; internal set; }

        public IList<Scan> Scans { get; set; }
    }
}
