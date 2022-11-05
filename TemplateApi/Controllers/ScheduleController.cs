using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;
using Contracts.Dto.Schedule;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : Controller {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService) => _scheduleService = scheduleService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDTO)
        {
            var scheduleResult = await _scheduleService.CreateSchedule(scheduleDTO);
            return Ok(scheduleResult);
        }

        [HttpGet("getSchedule/{id}")]
        public async Task<IActionResult> GetSchedule(int id) {
            var result = await _scheduleService.GetScheduleById(id);
            return Ok(result);
        }

        [HttpPut("updateSchedule")]
        public async Task<IActionResult> UpdateSchedule(ScheduleDto schedule) {
            var result = await _scheduleService.UpdateSchedule(schedule);
            return Ok(result);
        }

        [HttpDelete("deleteSchedule")]
        public async Task<IActionResult> DeleteSchedule(int id) {
            var result = await _scheduleService.DeleteSchedule(id);
            return Ok(result);
        }
    }
}
