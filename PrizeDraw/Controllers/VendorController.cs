using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.Models;
using PrizeDraw.DataLayer.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace PrizeDraw.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorDataAccessor _vendorDataAccessor;
        private readonly PrizeDataAccessor _prizeDataAccessor;
        private readonly AttendeeDataAccessor _attendeeDataAccessor;
        private readonly UserManager<User> _userManager;

        public VendorController(UserManager<User> userManger, PrizeDrawDatabaseContext context)
        {
            _userManager = userManger;
            _vendorDataAccessor = new VendorDataAccessor(context);
            _prizeDataAccessor = new PrizeDataAccessor(context);
            _attendeeDataAccessor = new AttendeeDataAccessor(context);
        }

        [Authorize(Roles="Admin")]
        //
        public IActionResult Index()
        {
            VendorIndexViewModel viewModel = new VendorIndexViewModel()
            {
                Vendors = _vendorDataAccessor.Get()
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                return View("CreateEdit", VendorCreateEditViewModel.From(_vendorDataAccessor.Get(id.Value)));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public IActionResult Edit([FromRoute] int? id, VendorCreateEditViewModel vendorModel)
        {
            IActionResult result;

            if (!ModelState.IsValid || !id.HasValue)
            {
                result = RedirectToAction("Create");
            }
            else
            {
                _vendorDataAccessor.UpdateVendor(id.Value, vendorModel.ToVendor());

                result = RedirectToAction("Index");
            }

            return result;
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            return View("CreateEdit", new VendorCreateEditViewModel());
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public IActionResult Create(VendorCreateEditViewModel viewModel)
        {
            IActionResult result;

            if (!ModelState.IsValid)
            {
                result = RedirectToAction("Create");
            }
            else
            {
               _vendorDataAccessor.InsertVendor(viewModel.ToVendor());

                result = RedirectToAction("Index");
            }

            return result;
        }

        [HttpGet]
        [Authorize(Roles="Vendor,Admin")]
        public async Task<IActionResult> CreateBallot()
        {
            IActionResult result;

            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (!currentUser.VendorId.HasValue)
            {
                return Error("User account does not have vendor associated");
            }
            else
            {
                int vendorId = currentUser.VendorId.Value;
                result = CreateBallotViewAction(vendorId);
            }

            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Vendor,Admin")]
        public async Task<IActionResult> CreateBallot(int attendeeId)
        {
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (!currentUser.VendorId.HasValue)
            {
                return Error("User account does not have vendor associated");
            }

            int vendorId = currentUser.VendorId.Value;
            string scannedAttendeeName = null;

            if (ModelState.IsValid && _attendeeDataAccessor.AttendeeExists(attendeeId))
            {
                _prizeDataAccessor.CreatePrizeTickets(vendorId, attendeeId);

                Attendee attendee = _attendeeDataAccessor.Get(attendeeId);
                scannedAttendeeName = attendee.FirstName + " " + attendee.LastName;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Attendee does not exist");
            }

            return CreateBallotViewAction(vendorId, scannedAttendeeName);
        }

        private IActionResult CreateBallotViewAction(int vendorId, string scannedAttendeeName = null)
        {
            VendorCreateBalllotViewModel viewModel = new VendorCreateBalllotViewModel()
            {
                AttendeesScanned = _attendeeDataAccessor.GetNumberOfAttendeesScannedBy(vendorId),
                TotalAttendees = _attendeeDataAccessor.GetNumberOfAttendees(),
                ScannedAttendeeName = scannedAttendeeName
            };

            return View("CreateBallot", viewModel);
        }

        public IActionResult Error(string message)
        {
            return View("Error", new ErrorViewModel { Message = message });
        }
    }
}