using DataTransferObjects.Dto.ViewModels;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Contracts
{
    public interface IProductService
    {
        #region CRUD
        public Task<bool> Add(ProductRequest requestDto, IFormFileCollection files, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, ProductRequest requestDto, IFormFileCollection files, CancellationToken cancellationToken);
        public Task<IEnumerable<ProductResponse>> GetAll();
        public Task<ProductResponse> GetById(int id);
        #endregion

        public Task<bool> ValidateNameId(int id, string name);
        public SelectListItemViewModel GetAllDropdownList();
    }
}
