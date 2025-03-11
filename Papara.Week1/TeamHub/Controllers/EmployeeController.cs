using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace TeamHub.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

     [HttpGet]
    public IEnumerable<Employee> GetAll()
    {
        var employees = _employeeService.GetAll();
        return employees;
    }

    [HttpGet("sync-employee")]
    public async Task SyncEmployeesAsync()
    {
         await _employeeService.SyncEmployeesAsync();
    }
}

