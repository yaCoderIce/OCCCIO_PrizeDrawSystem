using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Spire.Doc;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Providers;
using PrizeDraw.Models;
using System.Linq;

namespace PrizeDrawTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // To Change Command Line, right click on project -> Debug -> Application arguments:
                ProcessCommandLineArgs(args);
            }
            catch(Exception ex)// Catch General Exception
            {               
                //Display Error message
                if(ex.InnerException != null)
                {
                    Console.WriteLine("\n" + ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("\n" + ex.Message);
                }
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }
        /// <summary>
        /// ProcessCommandLineArgs - depending on argument supplied
        /// </summary>
        /// <param name="args">argument</param>
        private static void ProcessCommandLineArgs(string[] args)
        {
            if (args.Length == 0)
            {
                //Print Error Message
                PrintInvalidCommandLineUsageToConsole();
            }
            else if (args[0] == "b")
            {
                bool valid = false;
                string menuOption = "";

                do
                {
                    Console.WriteLine("1:Print all records.");
                    Console.WriteLine("2:Print specific records.");
                    menuOption = Console.ReadLine();
                    if(menuOption == "1" || menuOption == "2")
                    {
                        valid = true;
                    }
                } while (!valid);
                
                if (menuOption=="1")
                {
                    MailMerge();
                }
                else if (menuOption == "2")
                {
                    string userInput = "";
                    Console.WriteLine("Please enter the individuals id, seperated by (,) if many");
                    userInput = Console.ReadLine();
                    string[] listOfId = userInput.Split(',');

                    foreach(string id in listOfId)
                    {
                        Console.Write(id + " ");
                    }

                    try
                    {
                        MailMerge(listOfId);
                    }catch(Exception ex)
                    {
                        Console.WriteLine("\n"+ex.Message + "\nSomething happened! Please validate id again.");
                    }
                }
            }
            else if(args[0] == "u" || args[0] == "p")
            {
                // 2 is the minimum because of thats shortest possible directory eg C:
                if(args.Length != 2)
                {
                    Console.WriteLine("Invalid filepath");
                }
                else if(args[0] == "p")
                {
                    //generate user account with just the password
                    GenerateUsersAccounts(args[1], true);
                }
                else
                {
                    //generate user account
                    GenerateUsersAccounts(args[1], false);
                }
            }
            else
            {
                PrintInvalidCommandLineUsageToConsole();
            }
        }
        /// <summary>
        /// PrintInvalidCommandLineUsageToConsole - print out error message to the console
        /// </summary>
        private static void PrintInvalidCommandLineUsageToConsole()
        {
            Console.WriteLine("Invalid command line arguments");
            Console.WriteLine("Usage: PrizeDrawTool.exe <operation> <args>");
            Console.WriteLine("Generate Initial Vendor User Accounts and passwords: PrizeDrawTool.exe u <folder path>");
            Console.WriteLine("Generate New User Passwords: PrizeDrawTool.exe p <folder path>");
        }
        /// <summary>
        /// GenerateUsersAccounts - generate user for vendor or generate password for each users.
        /// </summary>
        /// <param name="outputPath">Location for output file</param>
        /// <param name="justPasswords">boolean</param>
        private static void GenerateUsersAccounts(string outputPath, bool justPasswords)
        {
            UserGenerator userGenerator = new UserGenerator(GetConnectionString(GetConfiguration()));

            bool running = true;
            Task workerTask = Task.Run(async () =>
            {
                try
                {
                    if (justPasswords)
                    {
                        await userGenerator.GenerateUserPasswords();
                    }
                    else
                    {
                        await userGenerator.GenerateUsersForVendors();
                    }

                    userGenerator.WritePasswordsToFile(outputPath);
                }
                finally
                {
                    running = false;
                }
            });

            Console.Write("Generating Users ");
            //Display loading icon (\,|,/,-)
            Spinner spinner = new Spinner();
            while(running)
            {
                spinner.PrintToConsole();
            }

            // Ensures any exceptions raised in the background thread gets thrown
            workerTask.Wait();
        }     
        /// <summary>
        /// GetConfiguration, get configuration from json file
        /// </summary>
        /// <returns>IConfigurationRoot</returns>
        private static IConfigurationRoot GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
        /// <summary>
        /// Provide Connection String to the database
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <returns>connection string</returns>
        private static string GetConnectionString(IConfiguration configuration)
        {
            string connectionStringName = string.Empty;
#if (DEV)
            connectionStringName = "PrizeDrawDatabaseDev";
#elif (PRD)
            connectionStringName = "PrizeDrawDatabaseProd";
#endif

            return configuration.GetConnectionString(connectionStringName);
        }

        private static void MailMerge()
        {
            /* MailMerge, is using FreeSpire.Doc mail merge functionality
             * the MailMerge.Execute also using IEnumerable meaning that we could pass it a list of attendees
             * It will search for the letterformatting.docx and perform mail merge on that document
             * 
             * 
             * Note:
             * After careful consideration, this year Durham College will only be using 3 templates (Attendee, Staff, Vendor)
             * due to security concern, three kind of name badge will be easily recognizable for security rather than ~40.
             * 
             */
            //Connection String
            string connectionString = GetConnectionString(GetConfiguration());
            
            //DataAccessor for attendee and vendor
            AttendeeDataAccessor _attendeeAccessor = new AttendeeDataAccessor(new PrizeDrawDatabaseContext(connectionString));
            VendorDataAccessor _vendorAccessor = new VendorDataAccessor(new PrizeDrawDatabaseContext(connectionString));
            
            //Declara new document for saving name badge
            Document document = new Document();
            
            // List of OCCCIO college name
            // may be useful in further development
            string[] collegeName = { "durhamCollege", "algonquinCollege", "cambrianCollege", "canadoreCollege", "centennialCollege", "collegeBoreal",
                "conestogaCollege","confederationCollege","fanshaweCollege","georgeBrownCollege","georgianCollege","humberCollege","laCite","lambtonCollege",
                    "loyalistCollege","mohawkCollege","niagaraCollege","northernCollege","saultCollege","senecaCollege","sheridanCollege","sirSandfordFlemingCollege",
                        "stClairCollege","stLawrenceCollege"};

            //Get all attendee from database
            IList<Attendee> attendees = _attendeeAccessor.Get();
            IList<Vendor> vendors = _vendorAccessor.Get();
            
            ////Split attendees to multiple record based on company
            ////Can be dangerous since the company should exactly matched
            ////Using LINQ
            //List<List<Attendee>> listOfList = attendees.GroupBy(a => a.Company)
            //                                 .Select(group => group.ToList())
            //                                 .ToList();
            //
            //// This part of code is to mail merge every company/college with the letterformating
            //// eg for DurhamCollege it will look for LetterFormatting_DurhamCollege.docx
            //foreach(List<Attendee> perCollege in listOfList)
            //{
            //    //show which company exist
            //    Console.WriteLine(perCollege[perCollege.Count-1].Company);
            //    try
            //    {
            //        document.LoadFromFile("../../../LetterFormatting_" + perCollege[perCollege.Count - 1].Company + ".doc", FileFormat.Doc);
            //        document.MailMerge.Execute(perCollege);
            //        document.SaveToFile("../../../Result_" + perCollege[perCollege.Count - 1].Company + ".docx", FileFormat.Docx);
            //        document.Close();
            //    }catch(Exception ex) //if the template doesnt exist
            //    {
            //        Console.Write(ex);
            //    }
            //}
            //Console.ReadKey();

            //List for staff, other, and vendor
            List<Attendee> staff    = new List<Attendee>();
            List<Attendee> other    = new List<Attendee>();
            List<Attendee> vendor   = new List<Attendee>();

            //boolea for checking vendor
            bool isVendor = false;

            foreach (Attendee attendee in attendees)
            {
                //Check if jobtitle is invalid
                if(int.TryParse(attendee.JobTitle.ToString(),out int result))
                {
                    attendee.JobTitle = "";
                }
                else if (attendee.JobTitle.Length > 20)
                {

                }
                
                //Check if name is longer than threshold
                const int MAX_LENGTH = 12;
                if ((attendee.FirstName.Length + attendee.LastName.Length) >= MAX_LENGTH)
                {
                    attendee.LastName = attendee.LastName.Substring(0, 1) + ".";
                }
                else // if name is shorter than 12
                {
                    //int spacing = MAX_LENGTH - (attendee.FirstName.Length + attendee.LastName.Length);
                    //attendee.FirstName = new string(' ', spacing / 2) + attendee.FirstName;
                    //attendee.LastName = attendee.LastName + new string(' ', (spacing / 2));
                    //attendee.LastName = null;
                    //Console.WriteLine(attendee.FirstName.ToString());
                }

                //Check if its vendor
                foreach(Vendor potentialVendor in vendors)
                {
                    if (attendee.Company == potentialVendor.Name)
                    {
                        vendor.Add(attendee);
                        isVendor = true;
                    }
                }

                if (attendee.Company == "Durham")
                {
                    staff.Add(attendee);
                }
                else if(isVendor==false)
                {
                    other.Add(attendee);
                    //Console.WriteLine((attendee.FirstName.Length + attendee.LastName.Length) + ", " + attendee.Id + ":" + attendee.FirstName + "" + attendee.LastName);
                }
                isVendor = false;
            }

            //Performing mail merge
            //wrapped inside a try catch for handling exception
            try
            {
                document.LoadFromFile("../../../LetterFormatting/LetterFormatting_Durham.doc", FileFormat.Doc);
                document.MailMerge.Execute(other);
                document.SaveToFile("../../../Result/Result_Other.docx", FileFormat.Docx);
                document.Close();
            }
            catch (FileNotFoundException ex) // If file cant be found
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex) // If file is in use
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                document.LoadFromFile("../../../LetterFormatting/LetterFormatting_Staff.doc", FileFormat.Doc);
                document.MailMerge.Execute(staff);
                document.SaveToFile("../../../Result/Result_Staff.docx", FileFormat.Docx);
                document.Close();
            }
            catch (FileNotFoundException ex) // If file cant be found
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex) // If file is in use
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                document.LoadFromFile("../../../LetterFormatting/LetterFormatting_Vendor.doc", FileFormat.Doc);
                document.MailMerge.Execute(vendor);
                document.SaveToFile("../../../Result/Result_Vendor.docx", FileFormat.Docx);
                document.Close();
            }
            catch (FileNotFoundException ex) // If file cant be found
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex) // If file is in use
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                document.LoadFromFile("../../../LetterFormatting/LetterFormatting.doc", FileFormat.Doc);
                document.MailMerge.Execute(attendees);
                document.SaveToFile("../../../Result/Result.docx", FileFormat.Docx);
                document.Close();
            }
            catch (FileNotFoundException ex) // If file cant be found
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex) // If file is in use
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private static void MailMerge(string[] listOfId)
        {
            //Connection String
            string connectionString = GetConnectionString(GetConfiguration());
            string errorMessage = "";

            //DataAccessor for attendee and vendor
            AttendeeDataAccessor _attendeeAccessor = new AttendeeDataAccessor(new PrizeDrawDatabaseContext(connectionString));
            VendorDataAccessor _vendorAccessor = new VendorDataAccessor(new PrizeDrawDatabaseContext(connectionString));

            //Declara new document for saving name badge
            Document document = new Document();

            // List of OCCCIO college name
            // may be useful in further development
            string[] collegeName = { "durhamCollege", "algonquinCollege", "cambrianCollege", "canadoreCollege", "centennialCollege", "collegeBoreal",
                "conestogaCollege","confederationCollege","fanshaweCollege","georgeBrownCollege","georgianCollege","humberCollege","laCite","lambtonCollege",
                    "loyalistCollege","mohawkCollege","niagaraCollege","northernCollege","saultCollege","senecaCollege","sheridanCollege","sirSandfordFlemingCollege",
                        "stClairCollege","stLawrenceCollege"};
            
            //Get all attendee from database
            IList<Attendee> attendees= new List<Attendee>();
            IList<Vendor> vendors = _vendorAccessor.Get();

            foreach (string id in listOfId)
            {
                //add attendee to the list
                Attendee attendee = _attendeeAccessor.Get(Convert.ToInt32(id));
                if (attendee != null)
                {
                    attendees.Add(attendee);
                }
                else
                {
                    errorMessage += "ID: " + id + " doesn't exist.";
                }
            }
            
            //List for staff, other, and vendor
            List<Attendee> staff = new List<Attendee>();
            List<Attendee> other = new List<Attendee>();
            List<Attendee> vendor = new List<Attendee>();

            //boolean for checking vendor
            bool isVendor = false;

            foreach (Attendee attendee in attendees)
            {
                if(attendee != null)
                {
                    //Check if name is longer than threshold
                    const int MAX_LENGTH = 12;
                    if ((attendee.FirstName.Length + attendee.LastName.Length) >= MAX_LENGTH)
                    {
                        attendee.LastName = attendee.LastName.Substring(0, 1) + ".";
                    }
                    else // if first name larger than threshold
                    {
                        //int spacing = MAX_LENGTH - (attendee.FirstName.Length + attendee.LastName.Length);
                        //attendee.FirstName = new string(' ', spacing / 2) + attendee.FirstName;
                        //attendee.LastName = attendee.LastName + new string(' ', (spacing / 2));
                        //attendee.LastName = null;
                        //Console.WriteLine(attendee.FirstName.ToString());
                    }

                    //Check if its vendor by comparing attendee company with vendor name
                    foreach (Vendor potentialVendor in vendors)
                    {
                        //set it to lower case to make it case insensitive
                        if (attendee.Company.ToLower() == potentialVendor.Name.ToLower())
                        {
                            vendor.Add(attendee);
                            isVendor = true;
                        }
                    }

                    //Check if company is durham, since if it is its a staff
                    //set it to lower case to make it case insensitive
                    if (attendee.Company.ToLower() == "durham")
                    {
                        staff.Add(attendee);
                    }
                    else if (isVendor == false)
                    {
                        other.Add(attendee);
                        //    //For Debugging
                        //    //Console.WriteLine((attendee.FirstName.Length + attendee.LastName.Length) + ", " + attendee.Id + ":" + attendee.FirstName + "" + attendee.LastName);
                    }
                    isVendor = false;
                }
            }

            //Performing mail merge
            //check if list is not empty, to prevent creating blank document
            if (errorMessage != "")
            {
                throw new InvalidDataException(errorMessage);
            }
            else
            {
                if (other.Count > 0)
                {
                    try
                    {
                        document.LoadFromFile("../../../LetterFormatting/LetterFormatting_Durham.doc", FileFormat.Doc);
                        document.MailMerge.Execute(other);
                        document.SaveToFile("../../../Result/Result_Other.docx", FileFormat.Docx);
                        document.Close();
                    }
                    catch (FileNotFoundException ex) // If file cant be found
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (IOException ex) // If file is in use
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (staff.Count > 0)
                {
                    try
                    {
                        document.LoadFromFile("../../../LetterFormatting/LetterFormatting_Staff.doc", FileFormat.Doc);
                        document.MailMerge.Execute(staff);
                        document.SaveToFile("../../../Result/Result_Staff.docx", FileFormat.Docx);
                        document.Close();
                    }
                    catch (FileNotFoundException ex) // If file cant be found
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (IOException ex) // If file is in use
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (vendor.Count > 0)
                {
                    try
                    {
                        document.LoadFromFile("../../../LetterFormatting/LetterFormatting_Vendor.doc", FileFormat.Doc);
                        document.MailMerge.Execute(vendor);
                        document.SaveToFile("../../../Result/Result_Vendor.docx", FileFormat.Docx);
                        document.Close();
                    }
                    catch (FileNotFoundException ex) // If file cant be found
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (IOException ex) // If file is in use
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (attendees != null)
                {
                    try
                    {
                        document.LoadFromFile("../../../LetterFormatting/LetterFormatting.doc", FileFormat.Doc);
                        document.MailMerge.Execute(attendees);
                        document.SaveToFile("../../../Result/Result.docx", FileFormat.Docx);
                        document.Close();
                    }
                    catch (FileNotFoundException ex) // If file cant be found
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (IOException ex) // If file is in use
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
