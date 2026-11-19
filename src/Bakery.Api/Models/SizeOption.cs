namespace Bakery.Api.Models;

public class SizeOption
{
    public int Id { get; set; }

    public int MenuItemId { get; set; }
    
    public MenuItem MenuItem { get; set; } = null!;

    public string Name { get; set; } = "";

    public int Tiers { get; set; }

    public long BasePricePence { get; set; }

    public int OvenUnits { get; set; }

    public int MaxFillings { get; set; }

    public bool IsActive { get; set; } = true;

    public List<SizeOptionPart> Parts { get; set; } = [];
}