using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PrizeDraw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Call CreateWebHostBuilder()
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Create IWebHostBuilder Interface
        /// (
        /// </summary>
        /// <param name="args">Command Line Argument</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            // Creating IWebHost with pre-configured defaults, and specify Startup as the type
            // @see Startup.cs
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
