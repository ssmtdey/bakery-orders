namespace Bakery.Api.Models;

public class SizeOptionPart
{
    public int Id { get; set; }
    
    public int SizeOptionId { get; set; }

    public SizeOption SizeOption { get; set; } = null!;

    public int PartSizeOptionId { get; set; }

    public SizeOption PartSizeOption { get; set; } = null!;

    public int Quantity { get; set; }
}