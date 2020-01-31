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
        /// <summary>
        /// GetScans - get all scans
        /// </summary>
        /// <returns>all scans</returns>
        public IEnumerable<Scan> GetScans()
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee);
        }
        /// <summary>
        /// GetScansForAttendee - get all scan of the attendee
        /// </summary>
        /// <param name="attendeeId">input attendee id</param>
        /// <returns>all scans of the attendee</returns>
        public IQueryable<Scan> GetScansForAttendee(int attendeeId)
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee)
                    .Where(s => s.AttendeeId == attendeeId);         
        }
        /// <summary>
        /// GetScansForVendor - get all scan of the vendor
        /// </summary>
        /// <param name="vendorId">input vendor id</param>
        /// <returns>all scans of the vendor</returns>
        public IQueryable<Scan> GetScansForVendor(int vendorId)
        {
            return DatabaseContext.Scans
                    .Include(v => v.Vendor)
                    .Include(a => a.Attendee)
                    .Where(s => s.VendorId == vendorId);
        }
        /// <summary>
        /// GetScanFor - get record from scan table
        /// </summary>
        /// <param name="vendorId">input vendor id</param>
        /// <param name="attendeeId">input attendee id</param>
        /// <returns>scan, of that record</returns>
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
