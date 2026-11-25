using System.ComponentModel.DataAnnotations;

namespace Bakery.Api.Contracts;

public record CreateSizeOptionRequest(
    [Range(1, int.MaxValue)] int MenuItemId,
    [Required, MaxLength(100)] string Name,
    [Range(1, 2)] int Tiers,
    [Range(1, 100_000_00)] long BasePricePence,
    [Range(0, 100)] int OvenUnits,
    [Range(1, 6)] int MaxFillings
);