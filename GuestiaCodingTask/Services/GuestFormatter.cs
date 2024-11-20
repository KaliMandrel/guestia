using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;

namespace GuestiaCodingTask.Services
{
    public class GuestFormatter : IGuestFormatter
    {
        public string PrintGuest(Guest guest)
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
