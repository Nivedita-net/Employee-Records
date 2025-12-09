using EmployeeDirectory.Models;

namespace EmployeeDirectory.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(EmployeeRequest employee);
        Task<List<Employee>?> GetAllEmployeesAsync();
    }
}
