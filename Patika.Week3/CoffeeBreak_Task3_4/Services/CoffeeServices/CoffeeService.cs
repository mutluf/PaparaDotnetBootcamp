using CoffeeBreak_Task3_4.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using CoffeeBreak_Task3_4.Entities;

namespace CoffeeBreak_Task3_4.Services.CoffeeServices;

public class CoffeeService : ICoffeeService
{
    private readonly CoffeeBreakDbContext _context;

    public CoffeeService(CoffeeBreakDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Coffee>> GetCoffeesAsync(string? name, string? size, string? orderBy)
    {
        var coffees = _context.Coffees.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            coffees = coffees.Where(c => c.Name.Contains(name));
        }

        if (!string.IsNullOrEmpty(size))
        {
            coffees = coffees.Where(c => c.Size.Equals(size, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(orderBy) && orderBy.Equals("price", StringComparison.OrdinalIgnoreCase))
        {
            coffees = coffees.OrderBy(c => c.Price);
        }

        return coffees;
    }

    public async Task<Coffee> GetCoffeeAsync(int id)
    {
        return await _context.Coffees.FindAsync(id);
    }

    public async Task<Coffee> CreateCoffeeAsync(Coffee coffee)
    {
        _context.Coffees.Add(coffee);
        await _context.SaveChangesAsync();
        return coffee;
    }

    public async Task<bool> UpdateCoffeeAsync(int id, Coffee coffee)
    {
        if (id != coffee.Id)
        {
            return false;
        }

        var existingCoffee = await _context.Coffees.FindAsync(id);
        if (existingCoffee == null)
        {
            return false;
        }

        existingCoffee.Name = coffee.Name;
        existingCoffee.Description = coffee.Description;
        existingCoffee.Price = coffee.Price;
        existingCoffee.Size = coffee.Size;
        existingCoffee.IsHot = coffee.IsHot;
        existingCoffee.IsIced = coffee.IsIced;
        existingCoffee.Ingredients = coffee.Ingredients;
        existingCoffee.StockQuantity = coffee.StockQuantity;
        existingCoffee.ImageUrl = coffee.ImageUrl;
        existingCoffee.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PatchCoffeeAsync(int id, JsonPatchDocument<Coffee> patchDocument)
    {
        var coffee = await _context.Coffees.FindAsync(id);

        if (coffee == null)
        {
            return false;
        }

        patchDocument.ApplyTo(coffee);
        coffee.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCoffeeAsync(int id)
    {
        var coffee = await _context.Coffees.FindAsync(id);

        if (coffee == null)
        {
            return false;
        }
        await _context.SaveChangesAsync();
        return true;
    }

    public IEnumerable<CoffeeDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public CoffeeDto GetById(int id)
    {
        throw new NotImplementedException();
    }
}
