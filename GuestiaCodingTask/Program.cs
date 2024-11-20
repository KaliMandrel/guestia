using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using System;
using System.Linq;
using GuestiaCodingTask.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GuestiaCodingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DbInitialiser.CreateDb();
            var context = new GuestiaContext();

            var results = context.Guests
                .Include(g => g.GuestGroup)
                .OrderBy(g => g.LastName)
                .ToList()
                .GroupBy(g => g.GuestGroup)
                .ToList();

            foreach (var resultSet in results)
            {
                Console.WriteLine(resultSet.Key.Name);
                foreach (var guest in resultSet)     
                {
                    Console.WriteLine(PrintGuest(guest));
                }
            }
        }

        static string PrintGuest(Guest guest)
        {
            return guest.GuestGroup.NameDisplayFormat switch
            {
                NameDisplayFormatType.LastNameCommaFirstNameInitial =>
                    $"{guest.LastName}, {guest.FirstName.Substring(0, 1)}",
                NameDisplayFormatType.UpperCaseLastNameSpaceFirstName =>
                    $"{guest.LastName.ToUpper()} {guest.FirstName}",
                _ => "N/A"
            };
        }
    }
    
}