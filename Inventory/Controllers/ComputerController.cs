using Inventory.Domain.ViewModels.Computers;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService) =>
            _computerService = computerService;

        [Route("Computer/Index/{id}")]
        public IActionResult Index(int id)
        {
            var computer = _computerService.GetOneComputer(id);

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
