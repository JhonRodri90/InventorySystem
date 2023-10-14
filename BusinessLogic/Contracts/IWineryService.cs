using DataTransferObjects.Dto.In;
using DataTransferObjects.Dto.Out;

namespace BusinessLogic.Contracts
{
    public interface IWineryService
    {
        #region CRUD

        public Task<bool> Add(WineryRequest requestDto, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> Update(int id, WineryRequest requestDto, CancellationToken cancellationToken);
        public Task<IEnumerable<WineryResponse>> GetAll();
        public Task<WineryResponse> GetById(int id);

        #endregion
    }
}
