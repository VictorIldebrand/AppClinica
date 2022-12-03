using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Student;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : Controller {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService) => _studentService = studentService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(StudentDto StudentDto) {
            var auth = await _studentService.CreateStudent(StudentDto);
            return Ok(auth);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _studentService.GetStudentById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(StudentDto student) {
            var result = await _studentService.UpdateStudent(student);
            return Ok(result);
        }

        [HttpPost("request-patient")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPatient() {
            var result = await _studentService.RequestPatient();
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            return Ok(result);
        }
    }
}
