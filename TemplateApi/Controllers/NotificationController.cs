using Contracts.Dto.Notification;
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
    public class NotificationController : Controller {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService) => _notificationService = notificationService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateNotification(NotificationDto notificationDTO) {
            var notificationResult = await _notificationService.CreateNotification(notificationDTO);
            return Ok(notificationResult);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetNotification(int id) {
            var result = await _notificationService.GetNotificationById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateNotification(NotificationDto notification) {
            var result = await _notificationService.UpdateNotification(notification);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNotification(int id) {
            var result = await _notificationService.DeleteNotification(id);
            return Ok(result);
        }
    }
}
