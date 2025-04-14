using CoffeeBreak.DTOs;
using CoffeeBreak.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace CoffeeBreak.Services.CoffeeServices;

public class FakeCoffeeService : ICoffeeService
{
    private readonly List<CoffeeDto> _coffees = new()
    {
        new CoffeeDto
        {
            Id = 1,
            Name = "Espresso",
            Description = "Strong and black coffee.",
            Price = 3.50m,
            Size = "Small",
            IsHot = true,
            IsIced = false,
            Ingredients = "Espresso shot",
            StockQuantity = 10,
            ImageUrl = "https://example.com/images/espresso.jpg"
        },
        new CoffeeDto
        {
            Id = 2,
            Name = "Iced Latte",
            Description = "Cold latte with milk.",
            Price = 4.75m,
            Size = "Medium",
            IsHot = false,
            IsIced = true,
            Ingredients = "Espresso, Milk, Ice",
            StockQuantity = 5,
            ImageUrl = "https://example.com/images/iced_latte.jpg"
        }
    };

    public Task<IQueryable<Coffee>> GetCoffeesAsync(string? name, string? size, string? orderBy)
    {
        throw new NotImplementedException();
    }

    public Task<Coffee> GetCoffeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Coffee> CreateCoffeeAsync(Coffee coffee)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCoffeeAsync(int id, Coffee coffee)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PatchCoffeeAsync(int id, JsonPatchDocument<Coffee> patchDocument)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCoffeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CoffeeDto> GetAll() => _coffees;

    public CoffeeDto GetById(int id) => _coffees.FirstOrDefault(c => c.Id == id);
}
