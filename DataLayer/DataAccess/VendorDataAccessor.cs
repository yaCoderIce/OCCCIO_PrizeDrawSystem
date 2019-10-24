using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Providers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.DataLayer.DataAccess
{
    public class VendorDataAccessor
    {
        private readonly VendorProvider _vendorProvider;

        public Vendor Get(int id)
        {
            return _vendorProvider.GetVendorBy(id);
        }

        public IList<Vendor> Get()
        {
            return _vendorProvider.GetVendors().ToList();
        }

        public VendorDataAccessor(PrizeDrawDatabaseContext context)
        {
            _vendorProvider = new VendorProvider(context);
        }

        public void InsertVendor(Vendor vendor)
        {
            _vendorProvider.Add(vendor);
            _vendorProvider.Save();
        }

        public void UpdateVendor(int id, Vendor vendor)
        {
            Vendor originalRecord = _vendorProvider.GetVendorBy(id);

            originalRecord.Logo = vendor.Logo;
            originalRecord.Name = vendor.Name;
            originalRecord.Users = vendor.Users;

            _vendorProvider.Save();
        }
    }
}
