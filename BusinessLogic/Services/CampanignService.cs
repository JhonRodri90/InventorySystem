using AutoMapper;
using BusinessLogic.AbstractLogic.Application;
using BusinessLogic.Contracts;
using Context.Entities;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Repository.GenericRepository.Interfaces;

namespace BusinessLogic.Services
{
    public class CampanignService : ICampanignService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CampanignService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(CampanignRequest requestDto, CancellationToken cancellationToken)
        {
            Campanign entity = mapper.Map<Campanign>(requestDto);
            await unitOfWork.CampanignRepository.Create(entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            await unitOfWork.CampanignRepository.Delete(id, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<CampanignResponse>> GetAll()
        {
            IEnumerable<Campanign?> data = await unitOfWork.CampanignRepository.ReadAll();
            IEnumerable<CampanignResponse> response = mapper.Map<IEnumerable<CampanignResponse>>(data);
            return response;
        }

        public async Task<CampanignResponse> GetById(int id)
        {
            Campanign? entity = await unitOfWork.CampanignRepository.ReadById(x => x.Id.Equals(id), includeProperties: string.Empty);
            CampanignResponse responseDto = mapper.Map<CampanignResponse>(entity);
            return responseDto;
        }

        public async Task<bool> Update(int id, CampanignRequest requestDto, CancellationToken cancellationToken)
        {
            Campanign entity = mapper.Map<Campanign>(requestDto);
            await unitOfWork.CampanignRepository.Update(id, entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> ValidateNameId(int id, string name)
        {
            IEnumerable<Campanign?> data = await unitOfWork.CampanignRepository.ReadAll();
            IEnumerable<CampanignResponse> response = mapper.Map<IEnumerable<CampanignResponse>>(data);
            return GenericValidation.ValidateDuplicateNameField(response, id, name);
        }
    }
}
