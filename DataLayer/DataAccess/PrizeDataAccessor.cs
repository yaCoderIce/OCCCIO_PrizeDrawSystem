using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrizeDraw.DataLayer.DataAccess
{
    public class PrizeDataAccessor
    {
        // Should be a configuration variable...but its fine here for now...
        public const int MaximumIndividualWins = 1;

        private PrizeProvider _prizeProvider;
        private ScanProvider _scanProvider;

        private static readonly Random _randomGenerator = new Random();

        public PrizeDataAccessor(PrizeDrawDatabaseContext context)
        {
            _prizeProvider = new PrizeProvider(context);
            _scanProvider = new ScanProvider(context);
        }

        public IList<Prize> Get()
        {
            return _prizeProvider.GetPrizes().ToList();
        }

        public Prize Get(int id)
        {
            return _prizeProvider.GetPrizeById(id);
        }

        /// <summary>
        /// Gets the next prize in an ordered list, sorted by Value then name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Prize GetNextPrize(int id)
        {
            List<Prize> prizes = _prizeProvider.GetPrizes(false).OrderBy(p => p.Value)
                .ThenBy(p => p.Name).ToList();

            int index = prizes.FindIndex(p => p.Id == id);

            Prize nextPrize = null;
            if (index >= 0 && index < prizes.Count-1)
            {
                nextPrize = prizes[index + 1];
            }

            return nextPrize;
        }

        public void Insert(Prize prize)
        {
            _prizeProvider.InsertPrize(prize);

            _prizeProvider.Save();
        }

        public void Update(int id, Prize prize)
        {
            Prize oldPrize = _prizeProvider.GetPrizeById(id);

            if (prize.Image != null && prize.Image.Length > 0)
            {
                oldPrize.Image = prize.Image;
            }
            oldPrize.Name = prize.Name;
            oldPrize.NumberAvailable = prize.NumberAvailable;
            oldPrize.VendorId = prize.VendorId;
            oldPrize.Value = prize.Value;

            _prizeProvider.Save();
        }

        public void CreatePrizeTickets(int vendorId, int attendeeId)
        {
            // Check to see if the vendor has already scanned the attendee. If they have, just ignore it.
            // Not really worth sending an error message. Everyone gets one ticket per vendor so just 
            // silently enfore that rule.
            if (!CheckTicketsAlreadyExists(vendorId, attendeeId))
            {
                InsertPrizeScan(vendorId, attendeeId);

                _prizeProvider.Save();
            }
        }

        public int GetTotalNumberOfAvailablePrizes()
        {
            return _prizeProvider.GetNumberOfUnwonPrizes();
        }

        /// <summary>
        /// Draws winners for all instances of of a prize
        /// </summary>
        /// <param name="prizeId"></param>
        /// <returns>List of tickets that were drawn as winners</returns>
        public IList<PrizeTicket> DrawPrizeWinners(int prizeId)
        {
            IList<PrizeTicket> winningTickets = new List<PrizeTicket>();

            int numberOfAvailiblePrizes = GetNumberPrizesAvailbleToDraw(prizeId);
            for (int i = 0; i < numberOfAvailiblePrizes; i++)
            {
                PrizeTicket winningTicket = DrawPrizeWinner(prizeId);
                if (winningTicket != null)
                {
                    winningTickets.Add(winningTicket);
                }
            }

            return winningTickets;
        }

        /// <summary>
        /// Draws winner for every prize and every instance of a prize
        /// </summary>
        /// <returns></returns>
        public IList<PrizeTicket> DrawPrizeWinners()
        {
            List<PrizeTicket> winnningTickets = new List<PrizeTicket>();

            foreach (Prize prize in Get())
            {
                winnningTickets.AddRange(DrawPrizeWinners(prize.Id));
            }

            return winnningTickets;
        }

        public PrizeTicket DrawPrizeWinner(int prizeId)
        {
            if(GetNumberPrizesAvailbleToDraw(prizeId) < 1)
            {
                throw new Exception("Attempted to draw for prize with no instances available");
            }

            IList<PrizeTicket> prizeTickets = GetEligiblePrizeTickets(prizeId);

            PrizeTicket winningTicket = null;
            int numberOfTickets = prizeTickets.Count();
            if (numberOfTickets > 0)
            {
                int winner = _randomGenerator.Next(numberOfTickets);
                winningTicket = prizeTickets[winner];

                InsertPrizeWinner(winningTicket.PrizeId, winningTicket.AttendeeId);
            }

            return winningTicket;
        }

        private void InsertPrizeWinner(int prizeId, int attendeeId)
        {
            _prizeProvider.AddWinner(new Winner
            {
                AttendeeId = attendeeId,
                PrizeId = prizeId
            });

            _prizeProvider.Save();
        }

        public void RemovePrizeWinner(int prizeId, int attendeeId)
        {
            _prizeProvider.RemoveWinner(_prizeProvider.GetPrizeWinner(prizeId, attendeeId).First());

            _prizeProvider.Save();
        }

        public int GetNumberPrizesAvailbleToDraw(int prizeId)
        {
            int numberOfWinners = _prizeProvider.GetPrizeWinners(prizeId).Count();
            int numberOfPrizes = Get(prizeId).NumberAvailable;

            return numberOfPrizes - numberOfWinners;
        }

        public int GetNumberOfEligibleBallots(int prizeId)
        {
            return GetEligiblePrizeTickets(prizeId).Count - GetNumberPrizesAvailbleToDraw(prizeId);
        }

        public int GetNumberOfPrizesWonByAttenedee(int attendeeId)
        {
            return _prizeProvider.GetAttendeePrizeWins(attendeeId).Count();
        }

        public IList<PrizeTicket> GetEligiblePrizeTickets(int prizeId)
        {
            IEnumerable<PrizeTicket> allTickets = GeneratePrizeTickets(prizeId);

            IEnumerable<int> inEligibleAttendees = GetAttendeesWithWinsGreaterThan(MaximumIndividualWins);

            List<PrizeTicket> eligibleTickets = (from at in allTickets
                                                where !inEligibleAttendees.Contains(at.AttendeeId)
                                                select at).ToList();

            return eligibleTickets;
        }

        public IList<int> GetAttendeesWithWinsGreaterThan(int winCount)
        {
            IEnumerable<Winner> winningTickets = _prizeProvider.GetPrizeWinners();

            IEnumerable<int> inEligibleAttendees = from at in winningTickets
                                                   group at by at.Attendee.Id into g
                                                   where g.Count() >= winCount
                                                   select g.Key;

            return inEligibleAttendees.ToList();
        }

        public IEnumerable<Winner> GetPrizeWinners()
        {
            return _prizeProvider.GetPrizeWinners();
        }

        public IList<Attendee> GetPrizeWinners(int prizeId)
        {
            return _prizeProvider.GetPrizeWinners(prizeId).Select(w => w.Attendee).ToList();
        }

        private bool CheckTicketsAlreadyExists(int vendorId, int attendeeId)
        {
            return _scanProvider.GetScanFor(vendorId, attendeeId) != null;
        }

        private void InsertPrizeScan(int vendorId, int attendeeId)
        {
            _scanProvider.Add(new Scan
            {
                VendorId = vendorId,
                AttendeeId = attendeeId
            });

            _scanProvider.Save();
        }

        private IList<PrizeTicket> GeneratePrizeTickets(int prizeId)
        {
            Prize prize = _prizeProvider.GetPrizeById(prizeId);

            IEnumerable<Scan> scans = (prize.VendorId.HasValue) ?
                _scanProvider.GetScansForVendor(prize.VendorId.Value) : _scanProvider.GetScans();

            List<PrizeTicket> prizeTickets = new List<PrizeTicket>();
            foreach (Scan scan in scans)
            {
                prizeTickets.Add(new PrizeTicket
                {
                    AttendeeId = scan.Attendee.Id,
                    PrizeId = prizeId,
                    VendorId = scan.Vendor.Id
                });
            }

            return prizeTickets;
        }
    }
}
