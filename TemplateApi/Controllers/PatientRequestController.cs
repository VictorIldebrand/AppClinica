using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;
using Contracts.Dto.PatientRequest;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientRequestController : Controller {
        private readonly IPatientRequestService _patientRequestService;

        public PatientRequestController(IPatientRequestService patientRequestService) => _patientRequestService = patientRequestService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePatient(PatientRequestDto patientRequestDto) {
            var patientRequestResult = await _patientRequestService.CreatePatientRequest(patientRequestDto);
            return Ok(patientRequestResult);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetPatientRequest(int id) {
            var result = await _patientRequestService.GetPatientRequestById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePatient(PatientRequestDto patientRequestDto) {
            var result = await _patientRequestService.UpdatePatientRequest(patientRequestDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePatientRequest(int id) {
            var result = await _patientRequestService.DeletePatientRequest(id);
            return Ok(result);
        }
    }
}
