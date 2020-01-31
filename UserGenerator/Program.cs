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

namespace PrizeDrawTool
{
    class Program
    {

        private static AttendeeDataAccessor _attendeeAccessor;
        
        static void Main(string[] args)
        {
            try
            {
                // To Change Command Line, right click on project -> Debug -> Application arguments:
                ProcessCommandLineArgs(args);
            }
            catch(Exception ex)
            {               
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

        private static void ProcessCommandLineArgs(string[] args)
        {
            if(args.Length == 0)
            {
                //Print Error Message
                PrintInvalidCommandLineUsageToConsole();
            }
            else if(args[0] == "u" || args[0] == "p" || args[0] == "b")
            {
                // 2 is the minimum because of thats shortest possible directory eg C:
                if(args.Length != 2)
                {
                    Console.WriteLine("Invalid filepath");
                }
                else if(args[0] == "p")
                {
                    GenerateUsersAccounts(args[1], true);
                }
                else if (args[0] == "b")
                {
                    MailMerge();
                }
                else
                {
                    GenerateUsersAccounts(args[1], false);
                }
            }
            else
            {
                PrintInvalidCommandLineUsageToConsole();
            }
        }
        /// <summary>
        /// PrintInvalidCommandLineUsageToConsole - 
        /// </summary>
        private static void PrintInvalidCommandLineUsageToConsole()
        {
            Console.WriteLine("Invalid command line arguments");
            Console.WriteLine("Usage: PrizeDrawTool.exe <operation> <args>");
            Console.WriteLine("Generate Initial Vendor User Accounts and passwords: PrizeDrawTool.exe u <folder path>");
            Console.WriteLine("Generate New User Passwords: PrizeDrawTool.exe p <folder path>");
        }
        
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

            Spinner spinner = new Spinner();
            while(running)
            {
                spinner.PrintToConsole();
            }

            // Ensures any exceptions raised in the background thread gets thrown
            workerTask.Wait();
        }     

        private static IConfigurationRoot GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

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
            Document document = new Document();
            
            document.LoadFromFile("../../../LetterFormatting.doc", FileFormat.Doc);
            string[] fieldNames = { "FirstName","LastName", "Company", "JobTitle", "Id", "Id" };
            string[] fieldValues = { "Abdellah El", "Bilali", "Algonquin College", "Enterprise Business Platforms", "931854203", "931854203" };

            //Console.WriteLine(_attendeeAccessor.Get());

            IList<Attendee> attendees = _attendeeAccessor.Get();

            document.MailMerge.Execute(attendees);

            document.SaveToFile("../../../Result.docx", FileFormat.Docx);
            document.Close();
            //System.Diagnostics.Process.Start("../.../../Result.docx");
            
        }

    }
}
