using EmployeeDirectory.Models;
using EmployeeDirectory.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequest employeeData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            var createdEmployee = await _employeeRepository.AddEmployeeAsync(employeeData);

            return CreatedAtAction(nameof(CreateEmployee),
                new { id = createdEmployee.Id },
                createdEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();

            return Ok(employees);
        }
    }
}
