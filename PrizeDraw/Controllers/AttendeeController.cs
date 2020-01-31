using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Spire.Doc;

namespace PrizeDraw.Controllers
{
    public class AttendeeController : Controller
    {
        private AttendeeDataAccessor _attendeeAccessor;

        public AttendeeController(PrizeDrawDatabaseContext context)
        {
            _attendeeAccessor = new AttendeeDataAccessor(context);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        // GET: Attendee
        public IActionResult Index()
        {
            return View(new AttendeeIndexViewModel()
            {
                Attendees = _attendeeAccessor.Get()
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        // GET: Attendee/Details/5
        public IActionResult Details(int id)
        {
            return View(_attendeeAccessor.Get(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        // GET: Attendee/Create
        public IActionResult Create()
        {
            return View("CreateEdit", new Attendee());
        }

        // POST: Attendee/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Attendee attendee)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                _attendeeAccessor.Insert(attendee);

                result = RedirectToAction(nameof(Index));
            }
            else
            {
                result = RedirectToAction("CreateEdit");
            }

            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        // GET: Attendee/Edit/5
        public IActionResult Edit(int id)
        {
            return View("CreateEdit", _attendeeAccessor.Get(id));
        }

        // POST: Attendee/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Attendee attendee)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                attendee.Id = id;
                _attendeeAccessor.Update(attendee);

                result = RedirectToAction("Index");
            }
            else
            {
                result = RedirectToAction("CreateEdit");
            }

            return result;
        }
        /// <summary>
        /// Import Button Event handler
        /// </summary>
        /// <param name="attendeeFile">csv file</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles="Admin")]
        public IActionResult Import(IFormFile attendeeFile)
        {
            int numberImportedAttendees = 0;
            //Code Added To check file extension
            //string extension = (Path.GetExtension(attendeeFile.FileName)).ToLower();
            //Check if Input file is good
            if (/*extension!="csv" ||*/ attendeeFile == null || attendeeFile.Length == 0)
            {
                ModelState.AddModelError("attendeeFile", "Invalid file");
            }
            else
            {
                try
                {
                    //Safe way to read a file
                    using (Stream fileStream = attendeeFile.OpenReadStream())
                    {  
                        numberImportedAttendees = _attendeeAccessor.ImportFromFile(fileStream);
                    }
                }
                catch (FormatException ex)
                {
                    ModelState.AddModelError("attendeeFile", ex.Message);
                    foreach(ValidationResult validationResult in _attendeeAccessor.ValidationResults)
                    {
                        ModelState.AddModelError(string.Empty, validationResult.ErrorMessage);
                    }
                }
            }

            return View("Index", new AttendeeIndexViewModel()
            {
                Attendees = _attendeeAccessor.Get(),
                NumberImportedAttendees = numberImportedAttendees
            });
        }
        /*
        /// <summary>
        /// Export Button Event handler
        /// </summary>
        /// <param name="attendeeFile">csv file</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Export()
        {
            //FileStream fileStreamPath = new FileStream(@"Data/LetterFormatting.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Document document = new Document();
                document.LoadFromFile(@"Data/LetterFormatting.docx", FileFormat.Docx);
                //string[] fieldNames = { "Name", "College", "JobTitle", "Barcode", "Barcode" };
                //string[] fieldValues = { "Abdellah El Bilali", "Algonquin College", "Enterprise Business Platforms", "931854203", "931854203" };

                IList<Attendee> attendees = _attendeeAccessor.Get();
                
                document.MailMerge.Execute(attendees);

                MemoryStream stream = new MemoryStream();
                document.SaveToFile(@"Result.docx", FileFormat.Docx);
                document.Close();
                System.Diagnostics.Process.Start(@"Result.docx");
            
        }
        */
    }
}