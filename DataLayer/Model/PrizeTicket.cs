using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.DataLayer.Model
{
    /// <summary>
    /// PrizeTicket Class
    /// used to generate winner for prize
    /// </summary>
    public class PrizeTicket
    {
        public int PrizeId { get; set; }

        public int AttendeeId { get; set; }

        public int VendorId { get; set; }
    }
}
