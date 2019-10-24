using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class CheckInIndexViewModel
    {
        [Required]
        public int? AttendeeId { get; set; }

        public string CheckedInAttendeeName { get; set; }

        public int TotalAttendees { get; set; }

        public int CheckedInAttendees { get; set; }
    }
}
