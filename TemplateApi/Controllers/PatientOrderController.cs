using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;
using Contracts.Dto.PatientOrder;
using Contracts.Entities;

namespace TemplateApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PacientOrderController : Controller {
        private readonly IPacientOrderService _pacientOrderService;

        public PacientOrderController(IPacientOrderService pacientOrderService) => _pacientOrderService = pacientOrderService;

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePacientOrder(PacientOrderDto PacientOrderDto) {
            var pacientOrderResult = await _pacientOrderService.CreatePatientOrder(PacientOrderDto);
            return Ok(pacientOrderResult);
        }

        [HttpGet("getpacientorder/{id}")]
        public async Task<IActionResult> GetPacientOrder(int id) {
            var result = await _pacientOrderService.GetpacientOrderById(id);
            return Ok(result);
        }

        [HttpPut("updatepacientorder")]
        public async Task<IActionResult> UpdatePacientOrder(PacientOrderDto pacientOrder) {
            var result = await _pacientOrderService.UpdatepacientOrder(pacientOrder);
            return Ok(result);
        }

        [HttpPut("deletepacientorder")]
        public async Task<IActionResult> DeletePacientOrder(int id) {
            var result = await _pacientOrderService.DeletepacientOrder(id);
            return Ok(result);
        }
    }
}
