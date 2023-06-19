﻿using Inventory.Domain.ViewModels.Computers;
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

        public IActionResult ComputerInfo()
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
        public async Task<IActionResult> ComputerHandler()
        {
            var response = await _computerService.GetComputers();

            return Json(new { data = response.Data });
        }
    }
}