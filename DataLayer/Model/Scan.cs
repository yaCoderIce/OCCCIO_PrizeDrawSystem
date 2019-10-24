using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.DataLayer.Model
{
    public class Scan
    {
        public int AttendeeId { get; set; }

        public int VendorId { get; set; }

        public Attendee Attendee { get; set; }

        public Vendor Vendor { get; set; }
    }
}
