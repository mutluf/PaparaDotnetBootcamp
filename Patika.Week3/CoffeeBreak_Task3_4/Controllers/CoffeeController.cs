using AutoMapper;
using CoffeeBreak_Task3_4.Attributes;
using CoffeeBreak_Task3_4.Entities;
using CoffeeBreak_Task3_4.Services.CoffeeServices;
using CoffeeBreak_Task3_4.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBreak_Task3_4.Controllers;

[ApiController]
[Route("api/coffees")]
public class CoffeeController : ControllerBase
{
    private readonly ICoffeeService _coffeeService;
    private readonly IMapper _mapper;

    public CoffeeController(ICoffeeService coffeeService, IMapper mapper)
    {
        _coffeeService = coffeeService;
        _mapper = mapper;
    }

    [FakeAuthorize]
    [HttpGet("list")]
    public async Task<IActionResult> GetCoffees([FromQuery] string? name, [FromQuery] string? size, [FromQuery] string? orderBy)
    {
        var coffees = await _coffeeService.GetCoffeesAsync(name, size, orderBy);
        var coffeeViewModels = _mapper.Map<List<CoffeeViewModel>>(await coffees.ToListAsync());
        return Ok(coffeeViewModels);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffee(int id)
    {
        var coffee = await _coffeeService.GetCoffeeAsync(id);
        if (coffee == null)
        {
            return NotFound(new { message = "Coffee not found." });
        }

        return Ok(coffee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoffee([FromBody] Coffee coffee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdCoffee = await _coffeeService.CreateCoffeeAsync(coffee);
        return CreatedAtAction(nameof(GetCoffee), new { id = createdCoffee.Id }, createdCoffee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoffee(int id, [FromBody] Coffee coffee)
    {
        if (id != coffee.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var result = await _coffeeService.UpdateCoffeeAsync(id, coffee);
        if (!result)
        {
            return NotFound(new { message = "Coffee not found." });
        }

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchCoffee(int id, [FromBody] JsonPatchDocument<Coffee> patchDocument)
    {
        var result = await _coffeeService.PatchCoffeeAsync(id, patchDocument);
        if (!result)
        {
            return NotFound(new { message = "Coffee not found." });
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoffee(int id)
    {
        var result = await _coffeeService.DeleteCoffeeAsync(id);
        if (!result)
        {
            return NotFound(new { message = "Coffee not found." });
        }

        return NoContent();
    }
}
