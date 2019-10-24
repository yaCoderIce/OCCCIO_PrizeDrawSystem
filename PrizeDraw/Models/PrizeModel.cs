using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public decimal Value { get; set; }

        public byte[] LogoImage { get; set; }

        public string SponsorName { get; set; }

        public int NumberAvailable { get; set; }

        public int NumberOfWinners { get; set; }

        public static PrizeModel From(Prize prize)
        {
            return new PrizeModel
            {
                Id = prize.Id,
                Image = prize.Image,
                LogoImage = prize.Sponsor?.Logo,
                Name = prize.Name,
                NumberAvailable = prize.NumberAvailable,
                NumberOfWinners = prize.Winners.Count(),
                SponsorName = prize.Sponsor?.Name,
                Value = prize.Value
            };
        }
    }
}
