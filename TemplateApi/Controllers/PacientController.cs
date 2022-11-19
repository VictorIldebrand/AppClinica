using Contracts.Dto.Patient;
using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : Controller {
        private readonly IPatientService _PatientService;

        public PatientController(IPatientService PatientService) => _PatientService = PatientService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePatient(PatientDto PatientDto) {
            var PatientResult = await _PatientService.CreatePatient(PatientDto);
            return Ok(PatientResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPatient(int id) {
            var result = await _PatientService.GetPatientById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePatient(PatientDto Patient) {
            var result = await _PatientService.UpdatePatient(Patient);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletePatient(int id) {
            var result = await _PatientService.DeletePatient(id);
            return Ok(result);
        }
    }
}
