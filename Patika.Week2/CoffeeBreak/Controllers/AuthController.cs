
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CoffeeBreak.DTOs;

namespace CoffeeBreak.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        if (loginDto.Username == "admin" && loginDto.Password == "123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDto.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, "FakeScheme");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.User = principal;

            return Ok("Fake login successful!");
        }

        return Unauthorized("Invalid credentials.");
    }
    
    [HttpGet("throw")]
    public IActionResult ThrowTest()
    {
        throw new Exception("to test exception.");
    }
}
