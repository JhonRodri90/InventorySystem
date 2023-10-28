using BusinessLogic.Contracts;
using DataTransferObjects.Dto.ViewModels;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductRequest data, CancellationToken cancellationToken)
        {
            var files = HttpContext.Request.Form.Files;

            if (ModelState.IsValid)
            {
                bool resp = false;
                string process = string.Empty;
                if (data.Id == 0)
                {
                    resp = await service.Add(data, files, cancellationToken);
                    process = "created product";
                }
                else
                {
                    resp = await service.Update(data.Id, data, files, cancellationToken);
                    process = "updated product";
                }
                TempData[StaticDefination.Successful] = resp ? $"Successfully {process}" : $"Error {process}";
                return RedirectToAction(nameof(Index));
            }
            TempData[StaticDefination.Error] = "Error when trying to save product information";
            return View(data);
        }

        public async Task<IActionResult> Upsert(int? id)
        {

            ProductResponse result = new();
            if (id is not null)
                result = await service.GetById(id.GetValueOrDefault());
            else
                result.State = true;

            SelectListItemViewModel dropdownList = service.GetAllDropdownList();
            result.CategoryDropDownList = dropdownList.CategoryDropDownList;
            result.MarkDropDownList = dropdownList.MarkDropDownList;
            result.ParentDropDownList = dropdownList.ParentDropDownList;
            return result is null ? NotFound() : View(result);
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductResponse> result = await service.GetAll();
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
                message = !result ? "Error when trying to remove the product" : "product successfully deleted"
            });
        }

        [ActionName("ValidateNameId")]
        public async Task<IActionResult> ValidateNameId(string name, int id = 0)
        {
            return Json(new { data = await service.ValidateNameId(id, name) });
        }
        #endregion
    }
}