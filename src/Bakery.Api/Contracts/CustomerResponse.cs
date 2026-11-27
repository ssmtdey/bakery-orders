using Bakery.Api.Models;

namespace Bakery.Api.Contracts;

public record CustomerResponse(int Id, string Name, Channel Channel, string Handle, string? Phone);