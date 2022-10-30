using Contracts.DTO.PacientDTO;
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
    public class PacientController : Controller {
        private readonly IPacientService _pacientService;

        public PacientController(IPacientService pacientService) => _pacientService = pacientService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePacient(PacientDTO pacientDTO) {
            var pacientResult = await _pacientService.CreatePatient(pacientDTO);
            return Ok(pacientResult);
        }

        [HttpGet("getLoggedStudent")]
        public async Task<IActionResult> GetLoggedPacient() {
            var id = Pacient.GetPacientId();
            var result = await _studentService.GetPacientById(id);

            return Ok(result);
        }

        [HttpGet("getpacient/{id}")]
        public async Task<IActionResult> GetPacient(int id) {
            var result = await _pacientService.GetpacientById(id);
            return Ok(result);
        }

        [HttpPut("updatepacient")]
        public async Task<IActionResult> UpdatePacient(pacientDTO pacient) {
            var result = await _pacientService.Updatepacient(pacient);
            return Ok(result);
        }

        [HttpPut("deletepacient")]
        public async Task<IActionResult> DeletePacient(int id) {
            var result = await _pacientService.Deletepacient(id);
            return Ok(result);
        }
    }
}
