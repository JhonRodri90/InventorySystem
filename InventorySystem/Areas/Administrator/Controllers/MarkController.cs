using BusinessLogic.Contracts;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MarkController : Controller
    {
        private readonly IMarkService service;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MarkRequest Mark, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (Mark.Id == 0)
                {
                    await service.Add(Mark, cancellationToken);
                    TempData[StaticDefination.Successful] = "Successfully created Mark";
                }
                else
                {
                    TempData[StaticDefination.Successful] = "Successfully updated Mark";
                    await service.Update(Mark.Id, Mark, cancellationToken);
                }

                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save Mark information";
            return View(Mark);
        }
        public MarkController(IMarkService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            MarkResponse result = new();
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
            IEnumerable<MarkResponse> result = await service.GetAll();
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
                message = !result ? "Error when trying to remove the Mark" : "Mark successfully deleted"
            });
        }
        #endregion
    }
}
