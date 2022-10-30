using Contracts.DTO.EmployeeDTO;
using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employeeDTO) {
            var employeeResult = await _employeeService.CreateEmployee(employeeDTO);
            return Ok(employeeResult);
        }

        [HttpGet("getLoggedEmployee")]
        public async Task<IActionResult> GetLoggedEmployee() {
            var id = Employee.GetEmployeeId();
            var result = await _employeeService.GetEmployeeById(id);

            return Ok(result);
        }

        [HttpGet("getemployee/{id}")]
        public async Task<IActionResult> GetEmployee(int id) {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }

        [HttpPut("updateemployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee) {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpPut("deleteemployee")]
        public async Task<IActionResult> DeleteEmployee(int id) {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
