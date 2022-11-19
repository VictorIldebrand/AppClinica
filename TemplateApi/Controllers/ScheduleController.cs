using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Dto.Schedule;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : Controller {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService) => _scheduleService = scheduleService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDTO)
        {
            var scheduleResult = await _scheduleService.CreateSchedule(scheduleDTO);
            return Ok(scheduleResult);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSchedule(int id) {
            var result = await _scheduleService.GetScheduleById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateSchedule(ScheduleDto schedule) {
            var result = await _scheduleService.UpdateSchedule(schedule);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteSchedule(int id) {
            var result = await _scheduleService.DeleteSchedule(id);
            return Ok(result);
        }
    }
}
