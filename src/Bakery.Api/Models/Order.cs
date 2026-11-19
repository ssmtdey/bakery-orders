namespace Bakery.Api.Models;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public DateOnly PickupDate { get; set; }

    public TimeOnly PickupTime { get; set; }

    public OrderStatus Status { get; set; }

    public DeclineReason? DeclineReason { get; set; }

    public string? DeclineNote { get; set; }

    public long? QuotedTotalPence { get; set; }

    public DateTimeOffset? QuotedAt { get; set; }

    public PaymentMethod? PaymentMethod { get; set; } 

    public DateTimeOffset? PaidAt { get; set; }

    public long CancellationFeePence { get; set; }

    public DateOnly? BookedBakeDate { get; set; }

    public int BookedOvenUnits { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public List<OrderLine> Lines { get; set; } = [];

    public long TotalPence => Lines.Sum(l => l.TotalPence);
}