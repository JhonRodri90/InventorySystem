
using BusinessLogic.Contracts;
using DataTransferObjects.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class WineryController : Controller
    {
        private readonly IWineryService service;

        public IActionResult Index()
        {
            return View();
        }
        public WineryController(IWineryService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            WineryResponse result = new();
            if (id is not null)
                result = await service.GetById(id.GetValueOrDefault());
            else
                result.State = true;
            return result is null ? NotFound() : View(result);
        }

        #region API

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<WineryResponse> result = await service.GetAll();
            return Json(new { data = result });
        }

        #endregion
    }
}
