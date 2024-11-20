using GuestiaCodingTask.Data;
using System;
using System.Linq;
using GuestiaCodingTask.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GuestiaCodingTask.Services;

namespace GuestiaCodingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DbInitialiser.CreateDb();
            
            // Register our services
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IGuestService, GuestService>()
                .AddSingleton<IGuestFormatter, GuestFormatter>()
                .BuildServiceProvider();

            // retrieve our services
            var guestService = serviceProvider.GetService<IGuestService>();
            var consoleWriter = serviceProvider.GetService<IGuestFormatter>();
            // Get the guests
            var results = guestService.GetGuests();

            // Print to console
            foreach (var resultSet in results)
            {
                Console.WriteLine("***********");
                Console.WriteLine(resultSet.Key.Name);
                Console.WriteLine("***********");
                foreach (var guest in resultSet)
                {
                    // Use appropriate formatting
                    Console.WriteLine(consoleWriter.PrintGuest(guest));   
                }
            }
        }

        
    }
    
}
