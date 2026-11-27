using System.ComponentModel.DataAnnotations;
using Bakery.Api.Models;

namespace Bakery.Api.Contracts;

public record CreateCustomerRequest(
    [Required, MaxLength(100)] string Name,
    [Required] Channel? Channel,
    [Required, MaxLength(100)] string Handle,
    [MaxLength(20)] string? Phone
);