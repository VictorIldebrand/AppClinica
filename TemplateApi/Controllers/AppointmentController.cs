using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Appointment;
using System;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AppointmentController : Controller {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService) => _appointmentService = appointmentService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAppointment(AppointmentDto appointmentDTO) {
            var appointmentResult = await _appointmentService.CreateAppointment(appointmentDTO);
            return Ok(appointmentResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAppointment(DateTime date) {
            var result = await _appointmentService.GetAppointmentByDate(date);
            return Ok(result);
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAppointments() {
            var result = await _appointmentService.GetAppointments();
            return Ok(result);
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAppointment(AppointmentDto appointment) {
            var result = await _appointmentService.UpdateAppointment(appointment);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAppointment(int id) {
            var result = await _appointmentService.DeleteAppointment(id);
            return Ok(result);
        }
    }
}
