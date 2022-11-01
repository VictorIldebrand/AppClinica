using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PacientRequestController : Controller {
        private readonly IPacientRequestService _pacientRequestService;

        public PacientRequestController(IPacientRequestService pacientRequestService) => _pacientRequestService = pacientRequestService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePacient(PacientRequestDto PacientRequestDto) {
            var pacientRequestResult = await _pacientRequestService.CreatePatientRequest(PacientRequestDto);
            return Ok(pacientRequestResult);
        }

        [HttpGet("getpacientrequest/{id}")]
        public async Task<IActionResult> GetPacientRequest(int id) {
            var result = await _pacientRequestService.GetpacientRequestById(id);
            return Ok(result);
        }

        [HttpPut("updatepacientRequest")]
        public async Task<IActionResult> UpdatePacient(PacientRequestDto pacientRequest) {
            var result = await _pacientRequestService.UpdatepacientRequest(pacientRequest);
            return Ok(result);
        }

        [HttpPut("deletepacientRequest/{id}")]
        public async Task<IActionResult> DeletePacientRequest(int id) {
            var result = await _pacientRequestService.DeletepacientRequest(id);
            return Ok(result);
        }
    }
}
