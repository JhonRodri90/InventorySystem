using AutoMapper;
using BusinessLogic.AbstractLogic.Application;
using BusinessLogic.Contracts;
using Context.Entities;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Repository.GenericRepository.Interfaces;

namespace BusinessLogic.Services
{
    public class WineryService : IWineryService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public WineryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(WineryRequest requestDto, CancellationToken cancellationToken)
        {
            Winery entity = mapper.Map<Winery>(requestDto);
            await unitOfWork.WineryRepository.Create(entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            await unitOfWork.WineryRepository.Delete(id, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<WineryResponse>> GetAll()
        {
            IEnumerable<Winery?> data = await unitOfWork.WineryRepository.ReadAll();
            IEnumerable<WineryResponse> response = mapper.Map<IEnumerable<WineryResponse>>(data);
            return response;
        }

        public async Task<WineryResponse> GetById(int id)
        {
            Winery? entity = await unitOfWork.WineryRepository.ReadById(x => x.Id.Equals(id), includeProperties: string.Empty);
            WineryResponse responseDto = mapper.Map<WineryResponse>(entity);
            return responseDto;
        }

        public async Task<bool> Update(int id, WineryRequest requestDto, CancellationToken cancellationToken)
        {
            Winery entity = mapper.Map<Winery>(requestDto);
            await unitOfWork.WineryRepository.Update(id, entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> ValidateNameId(int id, string name)
        {
            IEnumerable<Winery?> data = await unitOfWork.WineryRepository.ReadAll();
            IEnumerable<WineryResponse> response = mapper.Map<IEnumerable<WineryResponse>>(data);
            return GenericValidation.ValidateDuplicateNameField(response, id, name);
        }
    }
}
