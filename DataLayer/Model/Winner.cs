using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.DataLayer.Model
{
    /// <summary>
    /// Winner Class
    /// used to generate new winner
    /// @see Winners table
    /// </summary>
    public class Winner
    {
        public int AttendeeId { get; set; }

        public int PrizeId { get; set; }

        public Attendee Attendee { get; set; }

        public Prize Prize { get; set; }
    }
}
