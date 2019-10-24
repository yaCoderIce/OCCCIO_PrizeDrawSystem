using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class AttendeeIndexViewModel
    {
        public IList<Attendee> Attendees { get; set; }

        public int? NumberImportedAttendees { get; set; }
    }
}
