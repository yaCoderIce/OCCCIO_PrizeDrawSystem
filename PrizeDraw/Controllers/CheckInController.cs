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
    public class CheckInController : Controller
    {
        private AttendeeDataAccessor _attendeeAccessor;

        public CheckInController(PrizeDrawDatabaseContext prizeDrawDatabaseContext)
        {
            _attendeeAccessor = new AttendeeDataAccessor(prizeDrawDatabaseContext);
        }

        [HttpGet]
        [Authorize(Roles = "Staff,Admin")]
        //GET: CheckIn
        public IActionResult Index()
        {
            return CreateIndexViewResult(string.Empty);
        }

        [HttpPost]
        [Authorize(Roles = "Staff,Admin")]
        //POST: CheckIn/CheckInAttendee
        public IActionResult CheckInAttendee(int attendeeId)
        {
            string checkedInAttendeeName = string.Empty;

            if (ModelState.IsValid && _attendeeAccessor.AttendeeExists(attendeeId))
            {
                if (!_attendeeAccessor.IsAttendeeCheckedIn(attendeeId))
                {
                    Attendee attendee = _attendeeAccessor.CheckInAttendee(attendeeId);
                    checkedInAttendeeName = attendee.FirstName + " " + attendee.LastName;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Attendee is already checked in");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Attendee does not exist");
            }

            return CreateIndexViewResult(checkedInAttendeeName);
        }
        /// <summary>
        /// CreateIndexViewResult - show info about checkin
        /// </summary>
        /// <param name="attendeeName">input attendee name</param>
        /// <returns></returns>
        private IActionResult CreateIndexViewResult(string attendeeName)
        {
            CheckInIndexViewModel checkInIndexViewModel = new CheckInIndexViewModel()
            {
                TotalAttendees = _attendeeAccessor.GetNumberOfAttendees(),
                CheckedInAttendees = _attendeeAccessor.GetNumberOfCheckedInAttendees(),
                CheckedInAttendeeName = attendeeName
            };

            return View("Index", checkInIndexViewModel);
        }
    }
}