using Azure;
using Inventory.Domain.Filters;
using Inventory.Domain.ViewModels.Computers;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComputerService _computerService;

        public HomeController(IComputerService computerService) =>
            _computerService = computerService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateComputerViewModel model)
        {
            var response = await _computerService.Create(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public async Task<IActionResult> ComputerHandler(DeviceFilter filter)
        {
            var response = await _computerService.GetComputers(filter);

            return Json(new { data = response.Data });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CreateComputerViewModel model)
        {
            var response = await _computerService.Delete(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }
    }
}