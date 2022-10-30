// using Contracts.Interfaces.Services;
// using Contracts.TransactionObjects.Login;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using Contracts.Utils;
// using Contracts.Dto.Student;
// using Contracts.Entities;

// namespace TemplateApi.Controllers {
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class StudentController : Controller {
//         private readonly IStudentService _studentService;

//         public StudentController(IStudentService studentService) => _studentService = studentService;

//         [HttpPost("create")]
//         [AllowAnonymous]
//         public async Task<IActionResult> Create(StudentDto StudentDto) {
//             var auth = await _studentService.Create(StudentDto);
//             return Ok(auth);
//         }

//         [HttpGet("getLoggedStudent")]
//         public async Task<IActionResult> GetLoggedStudent() {
//             var id = Student.GetStudentId();
//             var result = await _studentService.GetStudentById(id);

//             return Ok(result);
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> Retrieve(int id) {
//             var result = await _studentService.Retrieve(id);
//             return Ok(result);
//         }

//         [HttpPut("update/{id}")]
//         public async Task<IActionResult> Update(StudentDto student) {
//             var result = await _studentService.Update(student);
//             return Ok(result);
//         }

//         [HttpPut("delete/{id}")]
//         public async Task<IActionResult> Delete(int id) {
//             var result = await _studentService.Delete(id);
//             return Ok(result);
//         }

//         [HttpPost("request-patient")]
//         public async Task<IActionResult> RequestPatient() {
//             var result = await _studentService.requestPatient();
//             return Ok(result);
//         }
//     }
// }
