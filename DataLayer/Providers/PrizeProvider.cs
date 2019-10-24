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

        public Prize GetPrizeById(int id)
        {
            return (from p in DatabaseContext.Prizes
                    .Include(v => v.Sponsor)
                    where p.Id == id
                    select p).First();
        }

        public IQueryable<Prize> GetUnSponsoredPrizes()
        {
            return DatabaseContext.Prizes
                .Include(v => v.Sponsor)
                .Where(p => p.VendorId == null);
        }

        public IQueryable<Prize> GetSponsoredPrizes(int vendorId)
        {
            return DatabaseContext.Prizes
                .Include(v => v.Sponsor)
                .Where(p => p.VendorId == vendorId);
        }

        public IQueryable<Winner> GetPrizeWinners()
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee);
        }

        public IQueryable<Winner> GetPrizeWinners(int prizeId)
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee)
                .Where(w => w.PrizeId == prizeId);
        }

        public IQueryable<Winner> GetAttendeePrizeWins(int attendeeId)
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee)
                .Where(w => w.AttendeeId == attendeeId );
        }

        public IQueryable<Winner> GetPrizeWinner(int prizeId, int attendeeId)
        {
            return DatabaseContext.Winners
                .Include(a => a.Attendee)
                .Where(w => w.PrizeId == prizeId && w.AttendeeId == attendeeId);
        }

        public IQueryable<Winner> GetAllWinningTickets()
        {
            return DatabaseContext.Winners
                .Include(w => w.Attendee)
                .Include(p => p.Prize);
        }

        public void InsertPrize(Prize prize)
        {
            DatabaseContext.Prizes.Add(prize);
        }

        public void AddWinner(Winner winner)
        {
            DatabaseContext.Add(winner);
        }

        public void RemoveWinner(Winner winner)
        {
            DatabaseContext.Remove(winner);
        }

        public int GetNumberOfUnwonPrizes()
        {
            return (from p in DatabaseContext.Prizes
                    where !DatabaseContext.Winners.Any(w => w.PrizeId == p.Id)
                    select p).Count();
        }
    }
}
