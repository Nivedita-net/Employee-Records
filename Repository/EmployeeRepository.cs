using AutoMapper;
using EmployeeDirectory.Models;
using Newtonsoft.Json;

namespace EmployeeDirectory.Repository
{
    public class EmployeeRepository(IMapper mapper) : IEmployeeRepository
    {
        private readonly string _filePath = "employees.json";
        private readonly IMapper _mapper = mapper;

        public async Task<Employee> AddEmployeeAsync(EmployeeRequest employeeRequest)
        {
            var employees = new List<Employee>();

            if (File.Exists(_filePath))
            {
                string json = await File.ReadAllTextAsync(_filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(json)
                                ?? new List<Employee>();
                }
            }
            var employee = _mapper.Map<Employee>(employeeRequest);
            employee.Id = employees.Count != 0 ? employees.Max(e => e.Id) + 1 : 1;

            employees.Add(employee);

            string updatedJson = JsonConvert.SerializeObject(employees, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, updatedJson);

            return employee;
        }

        public async Task<List<Employee>?> GetAllEmployeesAsync()
        {
            if (!File.Exists(_filePath))
                return null;

            string json = await File.ReadAllTextAsync(_filePath);
            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            return employees;
        }
    }
}
