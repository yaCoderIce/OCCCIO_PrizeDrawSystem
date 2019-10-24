using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class ManageIndexViewModel
    { 
        public Vendor NewVendor { get; set; }

        public IList<Vendor> Vendors { get; set; }

        public IList<User> Users { get; set; }
    }
}
