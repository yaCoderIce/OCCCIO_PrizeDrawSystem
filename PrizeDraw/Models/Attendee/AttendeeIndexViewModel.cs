using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class AttendeeIndexViewModel
    {
        //list of attendee
        public IList<Attendee> Attendees { get; set; }
        //Number imported attendee can be null
        public int? NumberImportedAttendees { get; set; }
    }
}
