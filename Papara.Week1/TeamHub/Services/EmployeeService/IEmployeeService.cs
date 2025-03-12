public interface IEmployeeService
{
    List<EmployeeDto> GetAll(int pageNumber, int pageSize);
    Task SyncEmployeesAsync();
    void AddEmployee(EmployeeCreateDto employee);
}