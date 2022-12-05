using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Professor;
using Microsoft.AspNetCore.Http;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProfessorController : Controller {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService) => _professorService = professorService;

        [HttpPost("create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProfessor(ProfessorDto professorDTO) {
            var professorResult = await _professorService.CreateProfessor(professorDTO);
            return Created("Professor criado",professorResult);
        }


        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProfessor(int id) {
            var result = await _professorService.GetProfessorById(id);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProfessor(ProfessorDto professor, int id) {
            var result = await _professorService.UpdateProfessor(professor, id);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProfessor(int id) {
            var result = await _professorService.DeleteProfessor(id);
            return Ok(result);
        }
    }
}
