using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;

namespace BusinessLogic.Contracts
{
    public interface ICampanignService
    {
        #region CRUD
        public Task<bool> Add(CampanignRequest requestDto, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, CampanignRequest requestDto, CancellationToken cancellationToken);
        public Task<IEnumerable<CampanignResponse>> GetAll();
        public Task<CampanignResponse> GetById(int id);
        #endregion

        public Task<bool> ValidateNameId(int id, string name);
    }
}
