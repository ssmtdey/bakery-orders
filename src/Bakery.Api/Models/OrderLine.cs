namespace Bakery.Api.Models;

public class OrderLine
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public int SizeOptionId { get; set; }

    public SizeOption SizeOption { get; set; } = null!;

    public int Quantity { get; set; }

    public Flavour Flavour { get; set; }

    public List<Filling> Fillings { get; set; } = [];

    public Occasion Occasion { get; set; }

    public string? OccasionDetail { get; set; }

    public string? Inscription { get; set; }

    public string ColourTheme { get; set; } = "";

    public string DesignNotes { get; set; } = "";

    public string InspoLink { get; set; } = "";

    public long BasePricePence { get; set; }

    public int OvenUnits { get; set; }

    public List<LineExtra> Extras { get; set; } = [];

    public long TotalPence => (BasePricePence * Quantity) + (Extras.Sum(e => e.Quantity * e.UnitPricePence));
}