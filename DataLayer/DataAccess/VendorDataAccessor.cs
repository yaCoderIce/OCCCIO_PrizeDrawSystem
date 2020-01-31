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
        /// <summary>
        /// Get - Get Vendor by vendor id
        /// </summary>
        /// <param name="id">vendor id</param>
        /// <returns>Vendor, by that specific id</returns>
        public Vendor Get(int id)
        {
            return _vendorProvider.GetVendorBy(id);
        }
        /// <summary>
        /// Get - Get all vendors
        /// </summary>
        /// <returns>List, of vendors</returns>
        public IList<Vendor> Get()
        {
            return _vendorProvider.GetVendors().ToList();
        }
        /// <summary>
        /// Create new vendor provider object
        /// </summary>
        /// <param name="context">vendor name</param>
        public VendorDataAccessor(PrizeDrawDatabaseContext context)
        {
            _vendorProvider = new VendorProvider(context);
        }
        /// <summary>
        /// InsertVendor - insert vendor
        /// </summary>
        /// <param name="vendor">Input Vendor</param>
        public void InsertVendor(Vendor vendor)
        {
            _vendorProvider.Add(vendor);
            _vendorProvider.Save();
        }
        /// <summary>
        /// Update Vendor Info
        /// </summary>
        /// <param name="id">vendor id</param>
        /// <param name="vendor">new vendor</param>
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
