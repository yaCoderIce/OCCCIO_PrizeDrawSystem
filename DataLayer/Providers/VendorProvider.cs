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
        public VendorProvider(string connectionString) : base(connectionString)
        {
        }

        public VendorProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Vendor GetVendorBy(int id)
        {
            return (from v in DatabaseContext.Vendors.Include(v => v.Users)
                    where v.Id == id
                    select v).First();
        }

        public IQueryable<Vendor> GetVendors()
        {
            return DatabaseContext.Vendors.Include(v => v.Users);
        }
    }
}
