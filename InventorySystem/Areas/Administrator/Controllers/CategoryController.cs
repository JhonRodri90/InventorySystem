using BusinessLogic.Contracts;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CategoryRequest category, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    await service.Add(category, cancellationToken);
                    TempData[StaticDefination.Successful] = "Successfully created category";
                }
                else
                {
                    TempData[StaticDefination.Successful] = "Successfully updated category";
                    await service.Update(category.Id, category, cancellationToken);
                }

                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save category information";
            return View(category);
        }
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            CategoryResponse result = new();
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
            IEnumerable<CategoryResponse> result = await service.GetAll();
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
                message = !result ? "Error when trying to remove the category" : "category successfully deleted"
            });
        }
        #endregion
    }
}
