using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Schedule;
using Microsoft.AspNetCore.Http;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ScheduleController : Controller {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService) => _scheduleService = scheduleService;

        [HttpPost("create")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDTO)
        {
            var scheduleResult = await _scheduleService.CreateSchedule(scheduleDTO);
            return Created("Agenda criada",scheduleResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSchedule(int id) {
            var result = await _scheduleService.GetScheduleById(id);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateSchedule(ScheduleDto schedule, int id) {
            var result = await _scheduleService.UpdateSchedule(schedule, id);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteSchedule(int id) {
            var result = await _scheduleService.DeleteSchedule(id);
            return Ok(result);
        }
    }
}
