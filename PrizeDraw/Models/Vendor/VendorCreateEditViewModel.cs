using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class VendorCreateEditViewModel
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public IFormFile Logo { get; set; }

        public static VendorCreateEditViewModel From(Vendor vendor)
        {
            return new VendorCreateEditViewModel
            {
                Name = vendor.Name
            };
        }

        public Vendor ToVendor()
        {
            Vendor vendor = new Vendor();

            vendor.Name = Name;

            if (Logo != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Logo.CopyTo(memoryStream);

                    vendor.Logo = memoryStream.ToArray();
                }
            }

            return vendor;
        }
    }
}
