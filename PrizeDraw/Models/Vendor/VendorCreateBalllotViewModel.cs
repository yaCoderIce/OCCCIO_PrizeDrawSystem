using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class VendorCreateBalllotViewModel
    {
        public int TotalAttendees { get; set; }

        public int AttendeesScanned { get; set; }

        [Required]
        public int? AttendeeId { get; set; }

        public string ScannedAttendeeName { get; set; }
    }
}
