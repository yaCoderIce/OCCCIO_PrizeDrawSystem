using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.Models;

namespace PrizeDraw.Controllers
{
    public class PrizeController : Controller
    {
        private readonly PrizeDataAccessor _prizeDataAccessor;
        private readonly VendorDataAccessor _vendorDataAccessor;
        private readonly AttendeeDataAccessor _attendeeDataAccessor;

        public PrizeController(PrizeDrawDatabaseContext context)
        {
            _prizeDataAccessor = new PrizeDataAccessor(context);
            _vendorDataAccessor = new VendorDataAccessor(context);
            _attendeeDataAccessor = new AttendeeDataAccessor(context);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        //GET:
        public IActionResult Index()
        {
            return View(PrizeIndexViewModel.From(_prizeDataAccessor.Get()));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        //GET:
        public IActionResult Edit(int id)
        {
            PrizeCreateEditViewModel viewModel = new PrizeCreateEditViewModel(_prizeDataAccessor.Get(id),
               _vendorDataAccessor.Get());

            return View("CreateEdit", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit([FromRoute] int? id, PrizeCreateEditViewModel prizeModel)
        {
            IActionResult result;

            if (ModelState.IsValid && id.HasValue)
            {
                Prize prize = prizeModel.ToPrize();

                _prizeDataAccessor.Update(id.Value, prize);

                result = RedirectToAction("Index");
            }
            else
            {
                result = RedirectToAction("Create");
            }

            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            return View(_prizeDataAccessor.Get(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            PrizeCreateEditViewModel viewModel = new PrizeCreateEditViewModel(_vendorDataAccessor.Get());

            return View("CreateEdit", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(PrizeCreateEditViewModel model)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                Prize prize = model.ToPrize();

                _prizeDataAccessor.Insert(prize);

                result = RedirectToAction("Index");
            }
            else
            {
                result = RedirectToAction("Create");
            }

            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult GenerateWinners()
        {
            int numberOfWinners = _prizeDataAccessor.DrawPrizeWinners().Count();

            PrizeIndexViewModel viewModel = PrizeIndexViewModel.From(_prizeDataAccessor.Get());
            viewModel.NumberOfWinnersDrawn = numberOfWinners;

            return View("Index", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DrawPrizeWinner([FromBody] GenericPostObject postObject)
        {
            IActionResult result = BadRequest();

            if (postObject != null && postObject.Id.HasValue)
            {
                PrizeWinnerModel winnerModel = DrawWinner(postObject.Id.Value);

                if (winnerModel != null)
                {
                    result = Ok(winnerModel);
                }
                else
                {
                    result = NoContent();
                }
            }

            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RedrawWinner([FromBody] RedrawWinnerPostModel model)
        {
            IActionResult result = BadRequest();

            if (model != null && model.PrizeId.HasValue && model.AttendeeId.HasValue)
            {
                _prizeDataAccessor.RemovePrizeWinner(model.PrizeId.Value, model.AttendeeId.Value);

                PrizeWinnerModel winnerModel = DrawWinner(model.PrizeId.Value);

                if (winnerModel != null)
                {
                    result = Ok(winnerModel);
                }
                else
                {
                    result = NoContent();
                }
            }

            return result;
        }

        private PrizeWinnerModel DrawWinner(int prizeId)
        {
            PrizeTicket winningTicket = null;
            Attendee winningAttendee = null;

            // Check to see if there are any prizes that are not won
            if (_prizeDataAccessor.GetNumberPrizesAvailbleToDraw(prizeId) > 0)
            {
                // Draw a prize winner
                winningTicket = _prizeDataAccessor.DrawPrizeWinner(prizeId);
                winningAttendee = _attendeeDataAccessor.Get(winningTicket.AttendeeId);
            }

            PrizeWinnerModel winnerModel = null;
            if (winningTicket != null)
            {
                winnerModel = new PrizeWinnerModel
                {
                    Name = winningAttendee.FirstName + " " + winningAttendee.LastName,
                    OrganizationName = winningAttendee.Company,
                    AttendeeId = winningAttendee.Id
                };
            }

            return winnerModel;
        }
    }
}