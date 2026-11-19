namespace Bakery.Api.Models;

public class WeekBooking
{
    public DateOnly BakeDate { get; set; }

    public int OvenUnitsBooked { get; set; }

    public Guid Version { get; set; }
}