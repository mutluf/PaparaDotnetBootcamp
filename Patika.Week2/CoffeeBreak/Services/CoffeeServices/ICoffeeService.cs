using CoffeeBreak.Entities;
using Microsoft.AspNetCore.JsonPatch;
namespace CoffeeBreak.Services.CoffeeServices;

public interface ICoffeeService
{
    Task<IQueryable<Coffee>> GetCoffeesAsync(string? name, string? size, string? orderBy);
    Task<Coffee> GetCoffeeAsync(int id);
    Task<Coffee> CreateCoffeeAsync(Coffee coffee);
    Task<bool> UpdateCoffeeAsync(int id, Coffee coffee);
    Task<bool> PatchCoffeeAsync(int id, JsonPatchDocument<Coffee> patchDocument);
    Task<bool> DeleteCoffeeAsync(int id);
}