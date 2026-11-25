namespace Bakery.Api.Contracts;

public record SizeOptionResponse(int Id, int MenuItemId, string Name, int Tiers,long BasePricePence, int MaxFillings, bool IsActive);