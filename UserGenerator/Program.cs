using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PrizeDrawTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
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
                PrintInvalidCommandLineUsageToConsole();
            }
            else if(args[0] == "u" || args[0] == "p")
            {
                if(args.Length != 2)
                {
                    Console.WriteLine("Invalid filepath");
                }
                else if(args[0] == "p")
                {
                    GenerateUsersAccounts(args[1], true);
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
    }
}
