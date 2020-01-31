using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Providers;

namespace PrizeDraw.DataLayer.DataAccess
{
    public class AttendeeDataAccessor
    {
        private AttendeeProvider _attendeeProvider;
        private static readonly Random _randomGenerator = new Random();

        public IList<ValidationResult> ValidationResults { get; private set; }
        /// <summary>
        /// Create new AttendeeProvider
        /// </summary>
        /// <param name="context"></param>
        public AttendeeDataAccessor(PrizeDrawDatabaseContext context)
        {
            _attendeeProvider = new AttendeeProvider(context);
        }

        public AttendeeDataAccessor()
        {
        }
        /// <summary>
        /// get attendee by id
        /// </summary>
        /// <param name="id">attendee id</param>
        /// <returns>attendee</returns>
        public Attendee Get(int id)
        {
            return _attendeeProvider.Get(id).FirstOrDefault();
        }

        /// <summary>
        /// Get list of attendees
        /// </summary>
        /// <returns>list, of attendees</returns>
        public IList<Attendee> Get()
        {
            return _attendeeProvider.Get().ToList();
        }

        /// <summary>
        /// Create new attendee
        /// </summary>
        /// <param name="attendee">attende</param>
        public void Insert(Attendee attendee)
        {
            attendee.Id = GenerateUniqueAttendeeId();

            _attendeeProvider.Add(attendee);

            _attendeeProvider.Save();
        }
        /// <summary>
        ///  Get number of attendees
        /// </summary>
        /// <returns>int, number of attendees</returns>
        public int GetNumberOfAttendees()
        {
            return _attendeeProvider.Get().Count();
        }
        /// <summary>
        /// Get number of check in attendees
        /// </summary>
        /// <returns>int, number of checked in</returns>
        public int GetNumberOfCheckedInAttendees()
        {
            return _attendeeProvider.Get().Count(a => a.IsCheckedIn);
        }
        /// <summary>
        /// Check if attendee exist in database
        /// </summary>
        /// <param name="id">attendee id</param>
        /// <returns>true or false</returns>
        public bool AttendeeExists(int id)
        {
            return _attendeeProvider.AttendeeExists(id);
        }
        /// <summary>
        /// Check In Attendee, set the IsCheckedIn attribute to true
        /// </summary>
        /// <param name="id">attendee id</param>
        /// <returns>attendee</returns>
        public Attendee CheckInAttendee(int id)
        {
            Attendee attendee = Get(id);

            attendee.IsCheckedIn = true;
            attendee.CheckedInTime = DateTime.Now;

            _attendeeProvider.Save();

            return attendee;
        }
        /// <summary>
        /// Check if attendee is checked in
        /// </summary>
        /// <param name="id">attendee id</param>
        /// <returns>true or false</returns>
        public bool IsAttendeeCheckedIn(int id)
        {
            return Get(id).IsCheckedIn;
        }

        /// <summary>
        /// Updates attendee data. This does not update checked in status or checked in time
        /// </summary>
        /// <param name="attendee">attendee</param>
        public void Update(Attendee attendee)
        {
            Attendee oldAttendee = _attendeeProvider.Get(attendee.Id).First();

            oldAttendee.Address1 = attendee.Address1;
            oldAttendee.Address2 = attendee.Address2;
            oldAttendee.City = attendee.City;
            oldAttendee.Company = attendee.Company;
            oldAttendee.Email = attendee.Email;
            oldAttendee.FirstName = attendee.FirstName;
            oldAttendee.LastName = attendee.LastName;
            oldAttendee.MobilePhone = attendee.MobilePhone;
            oldAttendee.PostalCode = attendee.PostalCode;
            oldAttendee.Province = attendee.Province;

            _attendeeProvider.Save();
        }
        /// <summary>
        /// Import from file to database
        /// </summary>
        /// <param name="fileStream">csv file</param>
        /// <returns>int, number of imported attendee</returns>
        public int ImportFromFile(Stream fileStream)
        {
            int numberImported = 0;

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                using (CsvReader csvReader = new CsvReader(streamReader))
                {
                    csvReader.Read();
                    csvReader.ReadHeader();

                    while(csvReader.Read())
                    {
                        Attendee attendee = CreateAttendeeFromCsv(csvReader);

                        ValidationResults = new List<ValidationResult>();
                        if(!Validator.TryValidateObject(attendee, new ValidationContext(attendee), ValidationResults))
                        {
                            throw new FormatException("Failed to validate data on line: " + numberImported);
                        }

                        if (!AttendeeExists(attendee.Id))
                        {
                            _attendeeProvider.Add(attendee);

                            numberImported++;
                        }
                    }
                }
            }

            if (numberImported > 0)
            {
                _attendeeProvider.Save();
            }

            return numberImported;
        }

        /// <summary>
        /// Create attendee from csv file
        /// </summary>
        /// <param name="csvReader">csv file</param>
        /// <returns>new attendee</returns>
        private Attendee CreateAttendeeFromCsv(CsvReader csvReader)
        {
            return new Attendee
            {
                Id = Convert.ToInt32(csvReader["Attendee #"]),
                FirstName = csvReader["First Name"],
                LastName = csvReader["Last Name"],
                Email = csvReader["Email"],
                MobilePhone = csvReader["Mobile Phone"],
                Company = csvReader["Company"],
                JobTitle = csvReader["Job Title"]
            };
        }
        /// <summary>
        /// Get number of attendee scanned by vendor
        /// </summary>
        /// <param name="vendorId">vendor id</param>
        /// <returns>int, number of attendee scanned by vendor</returns>
        public int GetNumberOfAttendeesScannedBy(int vendorId)
        {
            return _attendeeProvider.GetAttendeesScannedBy(vendorId).Count();
        }

        /// <summary>
        /// Generates a unique 8 digit id to use for attendess, if one does not exist.
        /// </summary>
        /// <returns>Unique 8 digit id</returns>
        private int GenerateUniqueAttendeeId()
        {
            int minVal = (int)Math.Pow(10,7);
            int maxVal = (int)Math.Pow(10, 8) - 1;

            const int cutOffPoint = 20;
            int attempts = 0;
            int id;
            do
            {
                id = _randomGenerator.Next(minVal, maxVal);

                // Safe gaurd from an infinite loop. This should never happen but if the data gets
                // suffiently saturated it could..
                if (++attempts >= cutOffPoint)
                {
                    throw new Exception("Failed to genreate unique Id in alloted time");
                }
            } while (AttendeeExists(id));

            return id;
        }
    }
}
