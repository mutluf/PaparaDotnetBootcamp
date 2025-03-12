using Microsoft.AspNetCore.Mvc;
using FluentValidation;
namespace TeamHub.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IValidator<EmployeeCreateDto> _validator;
    public EmployeeController(IEmployeeService employeeService, IValidator<EmployeeCreateDto> validator)
    {
        _employeeService = employeeService;
        _validator = validator;
    }

    [HttpGet]
    public IEnumerable<EmployeeDto> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var employees = _employeeService.GetAll(pageNumber, pageSize);
        return employees;
    }

    [HttpGet("sync-employee")]
    public async Task SyncEmployeesAsync()
    {
        await _employeeService.SyncEmployeesAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeCreateDto employeeDto)
    {
        var validationResult = await _validator.ValidateAsync(employeeDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                .ToList();
            return BadRequest(new { Errors = errors });
        }
        _employeeService.AddEmployee(employeeDto);

        return Ok("Employee created successfully!");
    }
}

