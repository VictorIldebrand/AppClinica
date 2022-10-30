using Contracts.DTO.ScheduleDTO;
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
    public class ScheduleController : Controller {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService) => _scheduleService = scheduleService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateSchedule(ScheduleDTO scheduleDTO)
        {
            var scheduleResult = await _scheduleService.Create(scheduleDTO);
            return Ok(scheduleResult);
        }

        [HttpGet("getSchedule/{id}")]
        public async Task<IActionResult> GetSchedule(int id) {
            var result = await _scheduleService.GetScheduleById(id);
            return Ok(result);
        }

        [HttpPut("updateSchedule")]
        public async Task<IActionResult> UpdateSchedule(ScheduleDTO schedule) {
            var result = await _scheduleService.UpdateSchedule(schedule);
            return Ok(result);
        }

        [HttpPut("deleteSchedule")]
        public async Task<IActionResult> DeleteSchedule(int id) {
            var result = await _scheduleService.DeleteSchedule(id);
            return Ok(result);
        }
    }
}
