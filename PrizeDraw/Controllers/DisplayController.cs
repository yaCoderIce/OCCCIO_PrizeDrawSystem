using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.Models;

namespace PrizeDraw.Controllers
{
    public class DisplayController : Controller
    {
        private PrizeDataAccessor _prizeDataAccessor;

        public DisplayController(PrizeDrawDatabaseContext context)
        {
            _prizeDataAccessor = new PrizeDataAccessor(context);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        //GET: Display
        //@see Views/Display/index.cstml
        public IActionResult Index()
        {
            return View(DisplayIndexViewModel.From(_prizeDataAccessor.Get()));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        //GET: Display
        //Display the information about the prize 
        //@see View/Display/Details/#
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            IActionResult result = BadRequest();
            Prize prize = null;
        
            try
            {
                prize = _prizeDataAccessor.Get(id.Value);
            }
            catch
            {
                // Failing to retreive a prize should just redirect back to the prize list.
                result = RedirectToAction("Index");
            }

            if (prize != null)
            {
                DisplayWinningTicketsViewModel displayWinningTicketsModel = new DisplayWinningTicketsViewModel
                {
                    PrizeImage = prize.Image,
                    NextPrizeId = _prizeDataAccessor.GetNextPrize(id.Value)?.Id,
                    PrizeName = prize.Name,
                    PrizeId = prize.Id,
                    NumberOfPrizes = prize.NumberAvailable,
                    SponsorLogo = prize.Sponsor?.Logo,
                    SponsorName = prize.Sponsor?.Name,
                    NumberOfBallots = _prizeDataAccessor.GetNumberOfEligibleBallots(id.Value),
                    PrizesAvailable = _prizeDataAccessor.GetNumberPrizesAvailbleToDraw(id.Value),
                    TotalNumberOfUnwonPrizes = _prizeDataAccessor.GetTotalNumberOfAvailablePrizes(),
                    Winners = _prizeDataAccessor.GetPrizeWinners(id.Value)
                };

                result = View(displayWinningTicketsModel);
            }

            return result;
        }
    }
}