using Inventory.Domain.ViewModels.Computers;
using Inventory.Service.Implementations;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;
        private readonly IQrCodeService _qrCodeService;

        public ComputerController(IComputerService computerService, IQrCodeService qrCodeService) =>
            (_computerService, _qrCodeService) = (computerService, qrCodeService);

        [Route("Computer/Index/{id}")]
        public IActionResult Index(int id)
        {
            var computer = _computerService.GetOneComputer(id);

            _qrCodeService.QrCodeGenerator($"https://localhost:44380/Computer/Index/{id}");

            return View(computer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComputer(UpdateComputerViewModel model)
        {
            var response = await _computerService.Update(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }
    }
}
