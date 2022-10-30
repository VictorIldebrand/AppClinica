// using Contracts.Interfaces.Services;
// using Contracts.TransactionObjects.Login;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using Contracts.Utils;
// using Contracts.Dto.Appointment;
// using System;

// namespace TemplateApi.Controllers {
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class AppointmentController : Controller {
//         private readonly IAppointmentService _appointmentService;

//         public AppointmentController(IAppointmentService appointmentService) => _appointmentService = appointmentService;

//         [HttpPost("create")]
//         public async Task<IActionResult> CreateAppointment(AppointmentDto appointmentDTO) {
//             var appointmentResult = await _appointmentService.CreateAppointment(appointmentDTO);
//             return Ok(appointmentResult);
//         }

//         [HttpGet("getappointment/{id}")]
//         public async Task<IActionResult> GetAppointment(DateTime date) {
//             var result = await _appointmentService.GetAppointmentByDate(date);
//             return Ok(result);
//         }

//         [HttpPut("updateappointment")]
//         public async Task<IActionResult> UpdateAppointment(AppointmentDto appointment) {
//             var result = await _appointmentService.UpdateAppointment(appointment);
//             return Ok(result);
//         }

//         [HttpPut("deleteappointment")]
//         public async Task<IActionResult> DeleteAppointment(int id) {
//             var result = await _appointmentService.DeleteAppointment(id);
//             return Ok(result);
//         }
//     }
// }
