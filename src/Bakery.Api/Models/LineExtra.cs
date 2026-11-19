namespace Bakery.Api.Models;

public class LineExtra
{
    public int Id { get; set; }

    public int OrderLineId { get; set; }

    public OrderLine OrderLine { get; set; } = null!;

    public int ExtraTypeId { get; set; }

    public ExtraType ExtraType { get; set; } = null!;

    public int Quantity { get; set; }

    public long UnitPricePence { get; set; }
}