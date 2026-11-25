using Bakery.Api.Contracts;
using Bakery.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Api.Controllers;

[ApiController]
[Route("size-options")]
public class SizeOptionsController : ControllerBase
{
    private readonly BakeryDbContext _db;

    public SizeOptionsController(BakeryDbContext db) => _db = db;

    [HttpGet]
    public async Task<List<SizeOptionResponse>> GetAll() =>
        await _db.SizeOptions
            .Select(s => new SizeOptionResponse(s.Id, s.MenuItemId, s.Name, s.Tiers, s.BasePricePence, s.MaxFillings, s.IsActive))
            .ToListAsync();
}