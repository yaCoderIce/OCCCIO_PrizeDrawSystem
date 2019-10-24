using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class PrizeIndexViewModel
    {
        public IList<PrizeModel> Prizes { get; set; }

        public int? NumberOfWinnersDrawn { get; set; }

        public static PrizeIndexViewModel From(IList<Prize> prizes)
        {
            List<PrizeModel> prizeModels = new List<PrizeModel>();
            foreach (Prize prize in prizes)
            {
                prizeModels.Add(PrizeModel.From(prize));
            }

            return new PrizeIndexViewModel
            {
                Prizes = prizeModels
            };
        }
    }
}
