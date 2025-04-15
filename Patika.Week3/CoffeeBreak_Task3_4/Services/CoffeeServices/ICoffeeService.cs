using CoffeeBreak_Task3_4.DTOs;
using CoffeeBreak_Task3_4.Entities;
using Microsoft.AspNetCore.JsonPatch;
namespace CoffeeBreak_Task3_4.Services.CoffeeServices;

public interface ICoffeeService
{
    Task<IQueryable<Coffee>> GetCoffeesAsync(string? name, string? size, string? orderBy);
    Task<Coffee> GetCoffeeAsync(int id);
    Task<Coffee> CreateCoffeeAsync(Coffee coffee);
    Task<bool> UpdateCoffeeAsync(int id, Coffee coffee);
    Task<bool> PatchCoffeeAsync(int id, JsonPatchDocument<Coffee> patchDocument);
    Task<bool> DeleteCoffeeAsync(int id);
    
    // for fake service
    IEnumerable<CoffeeDto> GetAll();
    CoffeeDto GetById(int id);
}