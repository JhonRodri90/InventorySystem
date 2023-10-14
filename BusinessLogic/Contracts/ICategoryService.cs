using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;

namespace BusinessLogic.Contracts
{
    public interface ICategoryService
    {
        #region CRUD
        public Task<bool> Add(CategoryRequest requestDto, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, CategoryRequest requestDto, CancellationToken cancellationToken);
        public Task<IEnumerable<CategoryResponse>> GetAll();
        public Task<CategoryResponse> GetById(int id);
        #endregion
    }
}
