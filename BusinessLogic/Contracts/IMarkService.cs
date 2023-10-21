using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;

namespace BusinessLogic.Contracts
{
    public interface IMarkService
    {
        #region CRUD
        public Task<bool> Add(MarkRequest requestDto, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, MarkRequest requestDto, CancellationToken cancellationToken);
        public Task<IEnumerable<MarkResponse>> GetAll();
        public Task<MarkResponse> GetById(int id);
        #endregion

        public Task<bool> ValidateNameId(int id, string name);
    }
}
