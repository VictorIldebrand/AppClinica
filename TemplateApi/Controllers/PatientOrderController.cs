// using Contracts.Interfaces.Services;
// using Contracts.TransactionObjects.Login;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using Contracts.Utils;
// using Contracts.Entities;
// using Contracts.RequestHandle;
// using Contracts.Dto.PatientOrder;
// using Business.Services;

// namespace TemplateApi.Controllers {
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class PatientOrderController : Controller
//     {
//         private readonly IPatientOrderService _patientOrderService;

//         public PatientOrderController(IPatientOrderService patientOrderService) => _patientOrderService = patientOrderService;

//         [HttpPost("create")]
//         [AllowAnonymous]
//         public async Task<IActionResult> CreatePatientOrder(PatientOrderDto patientOrder) {
//             var patientOrderResult = await _patientOrderService.CreatePatientOrder(patientOrder);
//             return Ok(patientOrderResult);
//         }

//         [HttpGet("get/{id}")]
//         public async Task<IActionResult> GetPatientOrder(int id) {
//             var result = await _patientOrderService.GetPatientOrderById(id);
//             return Ok(result);
//         }

//         [HttpPut("update")]
//         public async Task<IActionResult> UpdatePatientOrder(PatientOrderDto patientOrder) {
//             var result = await _patientOrderService.UpdatePatientOrder(patientOrder);
//             return Ok(result);
//         }

//         [HttpDelete("delete/{id}")]
//         public async Task<IActionResult> DeletePatientOrder(int id) {
//             var result = await _patientOrderService.DeletePatientOrder(id);
//             return Ok(result);
//         }
//     }
// }
