using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace PrizeDraw.DataLayer.Providers
{
    public class ScanProvider : Provider
    {
        public ScanProvider(string connectionString) : base(connectionString)
        {
        }

        public ScanProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public IEnumerable<Scan> GetScans()
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee);
        }

        public IQueryable<Scan> GetScansForAttendee(int attendeeId)
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee)
                    .Where(s => s.AttendeeId == attendeeId);         
        }

        public IQueryable<Scan> GetScansForVendor(int vendorId)
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee)
                    .Where(s => s.VendorId == vendorId);
        }

        public Scan GetScanFor(int vendorId, int attendeeId)
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee)
                    .Where(s => s.VendorId == vendorId && s.AttendeeId == attendeeId)
                    .FirstOrDefault();
        }
    }
}
