using BusinessLogic.Contracts;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(WineryRequest winery, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (winery.Id == 0)
                {
                    await service.Add(winery, cancellationToken);
                    TempData[StaticDefination.Successful] = "Successfully created winery";
                }
                else
                {
                    TempData[StaticDefination.Successful] = "Successfully updated winery";
                    await service.Update(winery.Id, winery, cancellationToken);
                }

                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save winery information";
            return View(winery);
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
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<WineryResponse> result = await service.GetAll();
            return Json(new { data = result });
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            bool result = false;
            if (id is not null)
                result = await service.Delete(id.GetValueOrDefault(), cancellationToken);
            return Json(new
            {
                success = result,
                message = !result ? "Error when trying to remove the Winery" : "Winery successfully deleted"
            });
        }
        #endregion
    }
}
