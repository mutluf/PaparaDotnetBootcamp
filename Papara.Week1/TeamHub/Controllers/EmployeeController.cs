using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamHub.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
     public string Get()
    {
        return "hello";
    }
}

