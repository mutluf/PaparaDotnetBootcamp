using System.Text.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
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
                    Name = api.Name,
                    Username = api.Name?.Replace(" ", ""),
                    Email = api.Email,
                    Phone = api.Phone,
                    Website = api.Website,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Gender = "Male",
                    NationalId = 12345678911,
                    Department = "Software Development",
                    Salary = 5000
                }).ToList();
            }
        }
    }
    public List<Employee> GetAll()
    {
        return _employees;
    }
}
public class ApiResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("userName")]
    public string? Username { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
}
