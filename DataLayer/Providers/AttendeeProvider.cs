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

        public IQueryable<Attendee> Get(int id)
        {
            return (from a in DatabaseContext.Attendees
                    where a.Id == id
                    select a);
        }

        public IQueryable<Attendee> Get()
        {
            return DatabaseContext.Attendees;
        }

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

        public IQueryable<Attendee> GetAttendeesScannedBy(int vendorId)
        {
            return (from s in DatabaseContext.Scans
                    join a in DatabaseContext.Attendees on s.AttendeeId equals a.Id
                    where s.VendorId == vendorId
                    select a);
        }
    }
}
