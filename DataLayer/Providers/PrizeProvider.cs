using PrizeDraw.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PrizeDraw.DataLayer.Providers
{
    public class PrizeProvider : Provider
    {
        public PrizeProvider(string connectionString) : base(connectionString)
        {
        }

        public PrizeProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }
        /// <summary>
        /// GetPrizes - get all prizes
        /// </summary>
        /// <param name="lazyLoad">lazy loading</param>
        /// <returns>prize</returns>
        public IQueryable<Prize> GetPrizes(bool lazyLoad = true)
        {
            IQueryable<Prize> prizes;
            if (lazyLoad) {
                prizes = DatabaseContext.Prizes
                        .Include(v => v.Sponsor)
                        .Include(w => w.Winners);
            }
            else
            {
                prizes = DatabaseContext.Prizes;
            }

            return prizes;
        }
        /// <summary>
        /// GetPrizeById - get prize by prize id
        /// </summary>
        /// <param name="id">input prize id</param>
        /// <returns>prize of the id</returns>
        public Prize GetPrizeById(int id)
        {
            return (from p in DatabaseContext.Prizes
                    .Include(v => v.Sponsor)
                    where p.Id == id
                    select p).First();
           
        }
        /// <summary>
        /// GetUnsporedPrizes - get all unsponsored prize
        /// </summary>
        /// <returns>unsponsored prize</returns>
        public IQueryable<Prize> GetUnSponsoredPrizes()
        {
            return DatabaseContext.Prizes
                .Include(v => v.Sponsor)
                .Where(p => p.VendorId == null);
        }
        /// <summary>
        /// GetSponsoredPrizes - get sponsored prize of the vendor id
        /// </summary>
        /// <param name="vendorId">input vendor id</param>
        /// <returns>sponsored prize</returns>
        public IQueryable<Prize> GetSponsoredPrizes(int vendorId)
        {
            return DatabaseContext.Prizes
                .Include(v => v.Sponsor)
                .Where(p => p.VendorId == vendorId);
        }
        /// <summary>
        /// GetPrizeWinners - get all prize winner
        /// </summary>
        /// <returns>winner</returns>
        public IQueryable<Winner> GetPrizeWinners()
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee);
        }
        /// <summary>
        /// GetPrizeWinners - get the winner of the prize
        /// </summary>
        /// <param name="prizeId">input prize id</param>
        /// <returns>winner</returns>
        public IQueryable<Winner> GetPrizeWinners(int prizeId)
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee)
                .Where(w => w.PrizeId == prizeId);
        }
        /// <summary>
        /// GetAttendeePrizeWins - get attendee prize
        /// </summary>
        /// <param name="attendeeId">input attendee id</param>
        /// <returns>attendee winner</returns>
        public IQueryable<Winner> GetAttendeePrizeWins(int attendeeId)
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee)
                .Where(w => w.AttendeeId == attendeeId );
        }
        /// <summary>
        /// GetPrizeWinner - 
        /// </summary>
        /// <param name="prizeId">input prize id</param>
        /// <param name="attendeeId">input attendee id</param>
        /// <returns></returns>
        public IQueryable<Winner> GetPrizeWinner(int prizeId, int attendeeId)
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee)
                .Where(w => w.PrizeId == prizeId && w.AttendeeId == attendeeId);
        }
        /// <summary>
        /// GetAllWinningTickets - get all winning tickets
        /// </summary>
        /// <returns>winning tickets</returns>
        public IQueryable<Winner> GetAllWinningTickets()
        {
            return DatabaseContext.Winners
                .Include(w => w.Attendee)
                .Include(p => p.Prize);
        }
        /// <summary>
        /// InsertPrize - insert prize
        /// </summary>
        /// <param name="prize">new prize</param>
        public void InsertPrize(Prize prize)
        {
            DatabaseContext.Prizes.Add(prize);
        }
        /// <summary>
        /// AddWinner - add winner
        /// </summary>
        /// <param name="winner">new winner</param>
        public void AddWinner(Winner winner)
        {
            DatabaseContext.Add(winner);
        }
        /// <summary>
        /// RemoveWinner - remove winner
        /// </summary>
        /// <param name="winner">Winner</param>
        public void RemoveWinner(Winner winner)
        {
            DatabaseContext.Remove(winner);
        }
        /// <summary>
        /// GetNumberOfUnwonPrizes - get number of unwon prizes
        /// </summary>
        /// <returns>int, number of unwon prize</returns>
        public int GetNumberOfUnwonPrizes()
        {
            return (from p in DatabaseContext.Prizes
                    where !DatabaseContext.Winners.Any(w => w.PrizeId == p.Id)
                    select p).Count();
        }
    }
}
