using System.Text.Json;
public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;
    private static List<Employee> _employees = new List<Employee>();
    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SyncEmployeesAsync()
    {
        _employees.Clear();
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var apiResponses = JsonSerializer.Deserialize<List<ApiResponse>>(jsonString);

            if (apiResponses != null)
            {
                _employees = apiResponses.Select(api => new Employee
                {
                    Id = api.Id,
                    Name = api.Name?.Split(" ")[0],
                    Surname = api.Name?.Split(" ").Length > 1 ? api.Name?.Split(" ")[1] : string.Empty,
                    Email = api.Email,
                    Phone = api.Phone,
                    Address = "",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Gender = Gender.Male,
                    NationalId = 12345678911,
                    Department = "Software Development",
                    Salary = 5000,
                    Age = 25
                }).ToList();
            }
        }
    }
    public List<EmployeeDto> GetAll(int pageNumber, int pageSize)
    {
        var results = _employees
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(e => new EmployeeDto
        {
            Name = e.Name,
            Department = e.Department,
            Surname = e.Surname,
            Email = e.Email,
            Phone = e.Phone,
            Gender = e.Gender.ToString()
        })
        .ToList();
        return results;
    }

    public void AddEmployee(EmployeeCreateDto employeeDto)
    {
        int newId = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
        Employee employee = new Employee
        {
            Id = newId,
            Name = employeeDto.Name,
            Surname = employeeDto.Surname,
            Email = employeeDto.Email,
            Phone = employeeDto.Phone,
            Address = employeeDto.Address,
            DateOfBirth = employeeDto.DateOfBirth,
            Gender = employeeDto.Gender,
            NationalId = employeeDto.NationalId,
            Department = employeeDto.Department,
            Salary = employeeDto.Salary,
            Age = DateTime.Today.Year - employeeDto.DateOfBirth.Year
        };
        _employees.Add(employee);
    }
}
