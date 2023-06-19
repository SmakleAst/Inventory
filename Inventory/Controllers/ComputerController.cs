using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService) =>
            _computerService = computerService;

        public IActionResult Index()
        {
            return View();
        }
    }
}
