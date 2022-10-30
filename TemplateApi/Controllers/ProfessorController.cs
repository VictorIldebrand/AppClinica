using Contracts.DTO.ProfessorDTO;
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
    public class ProfessorController : Controller {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService) => _professorService = professorService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProfessor(ProfessorDTO professorDTO) {
            var professorResult = await _professorService.CreateProfessor(professorDTO);
            return Ok(professorResult);
        }

        [HttpGet("getLoggedProfessor")]
        public async Task<IActionResult> GetLoggedProfessor() {
            var id = Professor.GetProfessorId();
            var result = await _professorService.GetProfessorById(id);

            return Ok(result);
        }

        [HttpGet("getprofessor/{id}")]
        public async Task<IActionResult> GetProfessor(int id) {
            var result = await _professorService.GetProfessorById(id);
            return Ok(result);
        }

        [HttpPut("updateprofessor")]
        public async Task<IActionResult> UpdateProfessor(ProfessorDTO professor) {
            var result = await _professorService.UpdateProfessor(professor);
            return Ok(result);
        }

        [HttpPut("deleteprofessor")]
        public async Task<IActionResult> DeleteProfessor(int id) {
            var result = await _professorService.DeleteProfessor(id);
            return Ok(result);
        }
    }
}
