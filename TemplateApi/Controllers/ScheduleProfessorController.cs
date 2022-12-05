using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.ScheduleProfessor;
using Microsoft.AspNetCore.Http;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ScheduleProfessorController : Controller {
        private readonly IScheduleProfessorService _scheduleProfessorService;

        public ScheduleProfessorController(IScheduleProfessorService scheduleProfessorService) => _scheduleProfessorService = scheduleProfessorService;

        [HttpPost("create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto)
        {
            var scheduleProfessorResult = await _scheduleProfessorService.CreateScheduleProfessor(scheduleProfessorDto);
            return Created("Agenda de professor criada",scheduleProfessorResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetScheduleProfessor(int id) {
            var result = await _scheduleProfessorService.GetScheduleProfessorById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto) {
            var result = await _scheduleProfessorService.UpdateScheduleProfessor(scheduleProfessorDto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteScheduleProfessor(int id) {
            var result = await _scheduleProfessorService.DeleteScheduleProfessor(id);
            return Ok(result);
        }
    }
}
