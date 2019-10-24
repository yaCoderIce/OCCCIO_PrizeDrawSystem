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

        public AttendeeDataAccessor(PrizeDrawDatabaseContext context)
        {
            _attendeeProvider = new AttendeeProvider(context);
        }

        public Attendee Get(int id)
        {
            return _attendeeProvider.Get(id).FirstOrDefault();
        }

        public IList<Attendee> Get()
        {
            return _attendeeProvider.Get().ToList();
        }

        public void Insert(Attendee attendee)
        {
            attendee.Id = GenerateUniqueAttendeeId();

            _attendeeProvider.Add(attendee);

            _attendeeProvider.Save();
        }

        public int GetNumberOfAttendees()
        {
            return _attendeeProvider.Get().Count();
        }

        public int GetNumberOfCheckedInAttendees()
        {
            return _attendeeProvider.Get().Count(a => a.IsCheckedIn);
        }

        public bool AttendeeExists(int id)
        {
            return _attendeeProvider.AttendeeExists(id);
        }

        public Attendee CheckInAttendee(int id)
        {
            Attendee attendee = Get(id);

            attendee.IsCheckedIn = true;
            attendee.CheckedInTime = DateTime.Now;

            _attendeeProvider.Save();

            return attendee;
        }

        public bool IsAttendeeCheckedIn(int id)
        {
            return Get(id).IsCheckedIn;
        }

        /// <summary>
        /// Updates attendee data. This does not update checked in status or checked in time
        /// </summary>
        /// <param name="attendee"></param>
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
