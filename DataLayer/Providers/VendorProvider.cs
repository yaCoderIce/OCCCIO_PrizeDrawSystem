using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace PrizeDraw.DataLayer.Providers
{
    public class VendorProvider : Provider
    {
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="connectionString">connection to database</param>
        public VendorProvider(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="databaseContext">database context</param>
        public VendorProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }
        /// <summary>
        /// Get Vendor info by vendor id
        /// </summary>
        /// <param name="id">vendor id</param>
        /// <returns>vendor, of that specific id</returns>
        public Vendor GetVendorBy(int id)
        {
            return (from v in DatabaseContext.Vendors.Include(v => v.Users)
                    where v.Id == id
                    select v).First();
        }
        /// <summary>
        /// GetVendors - get all vendors
        /// </summary>
        /// <returns></returns>
        public IQueryable<Vendor> GetVendors()
        {
            return DatabaseContext.Vendors.Include(v => v.Users);
        }
    }
}
