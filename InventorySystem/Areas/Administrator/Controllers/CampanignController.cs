using BusinessLogic.Contracts;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CampanignController : Controller
    {
        private readonly ICampanignService service;
        public CampanignController(ICampanignService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CampanignRequest campaign, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                campaign.DateUpdate = DateTime.Now;
                if (campaign.Id == 0)
                {
                    campaign.CreationDate = DateTime.Now;
                    await service.Add(campaign, cancellationToken);
                    TempData[StaticDefination.Successful] = "Successfully created campaign";
                }
                else
                {
                    TempData[StaticDefination.Successful] = "Successfully updated campaign";
                    await service.Update(campaign.Id, campaign, cancellationToken);
                }

                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save campaign information";
            return View(campaign);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            CampanignResponse result = new();
            if (id is not null)
                result = await service.GetById(id.GetValueOrDefault());

            return result is null ? NotFound() : View(result);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CampanignResponse> result = await service.GetAll();
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
                message = !result ? "Error when trying to remove the Campaign" : "Campaign successfully deleted"
            });
        }
        #endregion
    }
}
