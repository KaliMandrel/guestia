using System.Collections.Generic;
using System.Linq;
using GuestiaCodingTask.Data;
using Microsoft.EntityFrameworkCore;

namespace GuestiaCodingTask.Services
{
    public class GuestService : IGuestService
    {
        private readonly GuestiaContext _context;

        public GuestService()
        {
            _context = new GuestiaContext();
        }

        public IEnumerable<IGrouping<GuestGroup, Guest>> GetGuests()
        {
            var results = _context.Guests
                .Where(g => g.RegistrationDate == null)
                .Include(g => g.GuestGroup)
                .OrderBy(g => g.LastName)
                .ToList()
                .GroupBy(g => g.GuestGroup)
                .ToList();
            return results;
        }

    }
}