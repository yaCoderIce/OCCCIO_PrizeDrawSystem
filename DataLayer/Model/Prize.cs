using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrizeDraw.DataLayer.Model
{
    /// <summary>
    /// Prize Class
    /// used to generate prize
    /// @see Prizes table
    /// </summary>
    public class Prize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Value($)")]
        [Range(0, (double)decimal.MaxValue)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Value { get; set; }

        [Display(Name="Sponsor")]
        public int? VendorId { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [Range(1,1000)]
        [Display(Name="Number of Prizes")]
        public int NumberAvailable { get; set; }

        public IList<Winner> Winners { get; set; }

        public Vendor Sponsor { get; set; }
    }
}
