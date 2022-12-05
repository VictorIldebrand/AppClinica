using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Student;
using Microsoft.AspNetCore.Http;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : Controller {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService) => _studentService = studentService;

        [HttpPost("create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(StudentDto StudentDto) {
            var auth = await _studentService.CreateStudent(StudentDto);
            return Created("Estudante criado",auth);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _studentService.GetStudentById(id);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(StudentDto student, int id) {
            var result = await _studentService.UpdateStudent(student, id);
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
