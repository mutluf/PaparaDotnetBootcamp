using System.Text.Json.Serialization;

public class EmployeeCreateDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Gender Gender { get; set; }
    public long NationalId { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }
    public string? Address { get; set; }
}