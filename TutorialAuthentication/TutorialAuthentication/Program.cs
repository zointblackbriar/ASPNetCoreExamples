using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TutorialAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
                
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            } catch(Exception ex)
            {
                Console.WriteLine("An error happened: " + ex.Message);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //to change the port number
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5050");
    }
}
