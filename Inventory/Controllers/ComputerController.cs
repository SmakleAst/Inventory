using Inventory.DAL;
using Inventory.DAL.Interfaces;
using Inventory.Domain.Entity;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
