using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class PrizeCreateEditViewModel
    {
        public PrizeCreateEditViewModel()
        {
        }

        public PrizeCreateEditViewModel(IList<Vendor> vendors)
        {
            FillVendorsList(vendors);
        }

        public PrizeCreateEditViewModel(Prize prize, IList<Vendor> vendors)
        {
            Name = prize.Name;
            Value = prize.Value;
            VendorId = prize.VendorId;
            NumberAvailable = prize.NumberAvailable;

            FillVendorsList(vendors);
        }

        private void FillVendorsList(IList<Vendor> vendors)
        {
            Sponsors = new List<SelectListItem>();

            foreach(Vendor vendor in vendors)
            {
                ((List<SelectListItem>)Sponsors).Add(new SelectListItem()
                {
                    Text = vendor.Name,
                    Value = vendor.Id.ToString()
                });
            }
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Value($)")]
        [Range(0, (double)decimal.MaxValue)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Value { get; set; }

        [Display(Name = "Sponsor")]
        public int? VendorId { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Number of Prizes")]
        public int NumberAvailable { get; set; }

        public IEnumerable<SelectListItem> Sponsors { get; set; }

        public Prize ToPrize()
        {
            Prize prize = new Prize
            {
                Name = this.Name,
                NumberAvailable = this.NumberAvailable,
                Value = this.Value,
                VendorId = this.VendorId
            };

            if (Image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);

                    prize.Image = memoryStream.ToArray();
                }
            }

            return prize;
        }
    }
}
