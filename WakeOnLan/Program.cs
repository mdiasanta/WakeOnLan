using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WakeOnLan
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppSettings.json")
                    .Build();

                var Machines = configuration
                    .GetSection("Machines")
                    .Get<List<Machines>>();

                WakeService.WakeDevice(Machines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught! {ex}");
                Console.WriteLine("\nPress Any Key to Exit...");
                Console.ReadLine();
            }
        }
    }
}
