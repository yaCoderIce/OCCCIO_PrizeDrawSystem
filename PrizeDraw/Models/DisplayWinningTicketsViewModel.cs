using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class DisplayWinningTicketsViewModel
    { 
        public int PrizeId { get; set; }

        public int? NextPrizeId { get; set; }

        public string PrizeName { get; set; }

        public byte[] PrizeImage { get; set; }

        public int NumberOfPrizes { get; set; }

        public int TotalNumberOfUnwonPrizes { get; set; }

        public string SponsorName { get; set; }

        public byte[] SponsorLogo { get; set; }

        public int NumberOfBallots { get; set; }

        public int PrizesAvailable { get; set; }

        public IList<Attendee> Winners { get; set; }
    }
}
