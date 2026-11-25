using Bakery.Api.Contracts;
using Bakery.Api.Data;
using Bakery.Api.Models;
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SizeOptionResponse>> GetById(int id)
    {
        var s = await _db.SizeOptions.FindAsync(id);
        if (s is null) return NotFound();
        return new SizeOptionResponse(s.Id, s.MenuItemId, s.Name, s.Tiers, s.BasePricePence, s.MaxFillings, s.IsActive);
    }

    [HttpPost]
    public async Task<ActionResult<SizeOptionResponse>> Create(CreateSizeOptionRequest request)
    {
        var menuItemExists = await _db.MenuItems.AnyAsync(m => m.Id == request.MenuItemId);
        if (!menuItemExists) return BadRequest("Menu item does not exist.");

        var size = new SizeOption
        {
            MenuItemId = request.MenuItemId,
            Name = request.Name,
            Tiers = request.Tiers,
            BasePricePence = request.BasePricePence,
            OvenUnits = request.OvenUnits,
            MaxFillings = request.MaxFillings,
            IsActive = true
        };
        _db.SizeOptions.Add(size);
        await _db.SaveChangesAsync();

        var response = new SizeOptionResponse(size.Id, size.MenuItemId, size.Name, size.Tiers, size.BasePricePence, size.MaxFillings, size.IsActive);
        return CreatedAtAction(nameof(GetById), new { id = size.Id }, response);
    }
}