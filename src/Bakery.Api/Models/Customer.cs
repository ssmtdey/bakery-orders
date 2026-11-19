namespace Bakery.Api.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public Channel Channel { get; set; }

    public string Handle { get; set; } = ""; 

    public string? Phone { get; set; } 

    // One-to-many: a customer has many orders
    public List<Order> Orders { get; set; } = [];

    // To wipe personal details
    public DateTimeOffset? AnonymisedAt { get; set; }
}