using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace NetWorth.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config => {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("Data/SeedData/Countries.json");
                    config.AddJsonFile("Data/SeedData/RosterItems.json");
                    config.AddJsonFile("Data/SeedData/Users.json");
                })
                .UseStartup<Startup>();
    }
}
