using GuestiaCodingTask.Data;
using System.Collections.Generic;
using System.Linq;

namespace GuestiaCodingTask.Services
{
    public interface IGuestService
    {
        IEnumerable<IGrouping<GuestGroup, Guest>> GetGuests();
    }
}