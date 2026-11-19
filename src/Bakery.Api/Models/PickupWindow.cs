namespace Bakery.Api.Models;

public class PickupWindow
{
    public DayOfWeek Day { get; set; }

    public TimeOnly Opens { get; set; }

    public TimeOnly Closes { get; set; }
}