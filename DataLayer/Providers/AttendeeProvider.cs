using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrizeDraw.DataLayer.Model;

namespace PrizeDraw.DataLayer.Providers
{
    public class AttendeeProvider : Provider
    {
        public AttendeeProvider(string connectionString) : base(connectionString)
        {
        }

        public AttendeeProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }
        /// <summary>
        /// Get - get attendee by id
        /// </summary>
        /// <param name="id">input attendee id</param>
        /// <returns>attendee of the id</returns>
        public IQueryable<Attendee> Get(int id)
        {
            return (from a in DatabaseContext.Attendees
                    where a.Id == id
                    select a);
        }
        /// <summary>
        /// Get - get all attendee
        /// </summary>
        /// <returns>all attendee</returns>
        public IQueryable<Attendee> Get()
        {
            return DatabaseContext.Attendees;
        }
        /// <summary>
        /// AttendeeExists - check if the attendee exist
        /// </summary>
        /// <param name="id">input attendee id</param>
        /// <returns>true or false</returns>
        public bool AttendeeExists(int id)
        {
            return (from a in DatabaseContext.Attendees
                    .AsNoTracking()
                    where a.Id == id
                    select a).FirstOrDefault() != null ||
                    /* Check unsaved entries in memory as well */
                   ((from a in DatabaseContext.Attendees.Local
                     where a.Id == id
                     select a).FirstOrDefault() != null);
        }
        /// <summary>
        /// GetAttendeesScannedBy - get all attendees scanned by the vendor
        /// </summary>
        /// <param name="vendorId">input vendor id</param>
        /// <returns>list of attendee scanned by the vendor</returns>
        public IQueryable<Attendee> GetAttendeesScannedBy(int vendorId)
        {
            return (from s in DatabaseContext.Scans
                    join a in DatabaseContext.Attendees on s.AttendeeId equals a.Id
                    where s.VendorId == vendorId
                    select a);
        }
    }
}
