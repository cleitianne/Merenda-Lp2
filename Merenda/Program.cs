using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;



namespace Merenda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //BuildWebHost(args).Run();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:80") // Porta
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .Build();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(
                    options =>
                    {
                        options.AddServerHeader = false;
                        options.Listen(IPAddress.Loopback, 5000);
                    }
                )
                .Build();
    }
}
