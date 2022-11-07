using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;
using Contracts.Dto.Employee;
using Contracts.Entities;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateEmployee(EmployeeDto EmployeeDto) {
            var employeeResult = await _employeeService.CreateEmployee(EmployeeDto);
            return Ok(employeeResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployee(int id) {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employee) {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteEmployee(int id) {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
