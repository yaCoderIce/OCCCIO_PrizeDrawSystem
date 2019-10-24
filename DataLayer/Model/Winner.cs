using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.DataLayer.Model
{
    public class Winner
    {
        public int AttendeeId { get; set; }

        public int PrizeId { get; set; }

        public Attendee Attendee { get; set; }

        public Prize Prize { get; set; }
    }
}
