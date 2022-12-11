using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Appointment;
using System;
using Microsoft.AspNetCore.Http;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AppointmentController : Controller {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService) => _appointmentService = appointmentService;

        [HttpPost("create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAppointment(AppointmentDto appointmentDTO) {
            var appointmentResult = await _appointmentService.CreateAppointment(appointmentDTO);
            return Created("Consulta criada",appointmentResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAppointment(int id) {
            var result = await _appointmentService.GetAppointmentById(id);
            return Ok(result);
        }

        [HttpGet("get")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAppointments() {
            var result = await _appointmentService.GetAppointments();
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAppointment(AppointmentDto appointment, int id) {
            var result = await _appointmentService.UpdateAppointment(appointment, id);
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
