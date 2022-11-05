using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;
using Contracts.Dto.Schedule;
using Contracts.Dto.ScheduleProfessor;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleProfessorController : Controller {
        private readonly IScheduleProfessorService _scheduleProfessorService;

        public ScheduleProfessorController(IScheduleProfessorService scheduleProfessorService) => _scheduleProfessorService = scheduleProfessorService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto)
        {
            var scheduleProfessorResult = await _scheduleProfessorService.CreateScheduleProfessor(scheduleProfessorDto);
            return Ok(scheduleProfessorResult);
        }

        [HttpGet("getScheduleProfessor/{id}")]
        public async Task<IActionResult> GetScheduleProfessor(int id) {
            var result = await _scheduleProfessorService.GetScheduleProfessorById(id);
            return Ok(result);
        }

        [HttpPut("updateScheduleProfessor")]
        public async Task<IActionResult> UpdateScheduleProfessor(ScheduleProfessorDto scheduleProfessorDto) {
            var result = await _scheduleProfessorService.UpdateScheduleProfessor(scheduleProfessorDto);
            return Ok(result);
        }

        [HttpDelete("deleteScheduleProfessor")]
        public async Task<IActionResult> DeleteScheduleProfessor(int id) {
            var result = await _scheduleProfessorService.DeleteScheduleProfessor(id);
            return Ok(result);
        }
    }
}
