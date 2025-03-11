public interface IEmployeeService
{
    List<Employee> GetAll();
    Task SyncEmployeesAsync();
}