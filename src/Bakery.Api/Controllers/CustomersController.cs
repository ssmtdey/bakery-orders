using Bakery.Api.Contracts;
using Bakery.Api.Data;
using Bakery.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Api.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    private readonly BakeryDbContext _db;

    public CustomersController(BakeryDbContext db) => _db = db;

    [HttpGet]
    public async Task<List<CustomerResponse>> GetAll([FromQuery] string? search)
    {
        var query = _db.Customers.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(c => c.Name.ToLower().Contains(term) || c.Handle.ToLower().Contains(term));
        }

        return await query
            .Select(c => new CustomerResponse(
                Id: c.Id,
                Name: c.Name,
                Channel: c.Channel,
                Handle: c.Handle,
                Phone: c.Phone
            ))
            .ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerResponse>> GetById(int id)
    {
        var customer = await _db.Customers.FindAsync(id);
        if (customer is null) return NotFound();

        return new CustomerResponse(
            Id: customer.Id,
            Name: customer.Name,
            Channel: customer.Channel,
            Handle: customer.Handle,
            Phone: customer.Phone
        );
    }

    [HttpPost]
    public async Task<ActionResult<CustomerResponse>> Create(CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            Name = request.Name,
            Channel = request.Channel!.Value,
            Handle = request.Handle,
            Phone = request.Phone
        };

        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, new CustomerResponse(
            Id: customer.Id,
            Name: customer.Name,
            Channel: customer.Channel,
            Handle: customer.Handle,
            Phone: customer.Phone
        ));
    }
}