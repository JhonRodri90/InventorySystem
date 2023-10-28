using BusinessLogic.Contracts;
using DataTransferObjets.Dto.Out;
using DataTransferObjets.System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventorySystem.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService service;

        public HomeController(ILogger<HomeController> logger, IProductService service)
        {
            _logger = logger;
            this.service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<ProductResponse> data = await service.GetAll();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}