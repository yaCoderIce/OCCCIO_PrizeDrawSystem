using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    public class DisplayIndexViewModel
    {
        public IList<PrizeModel> Prizes { get; set; }

        public static DisplayIndexViewModel From(IEnumerable<Prize> prizes)
        {
            List<PrizeModel> prizeModels = new List<PrizeModel>();

            foreach (Prize prize in prizes)
            {
                prizeModels.Add(PrizeModel.From(prize));
            }

            return new DisplayIndexViewModel
            {
                Prizes = prizeModels
            };
        }
    }
}
