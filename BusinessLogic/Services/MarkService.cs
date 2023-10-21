using AutoMapper;
using BusinessLogic.AbstractLogic.Application;
using BusinessLogic.Contracts;
using Context.Entities;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Repository.GenericRepository.Interfaces;

namespace BusinessLogic.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public MarkService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(MarkRequest requestDto, CancellationToken cancellationToken)
        {
            Mark entity = mapper.Map<Mark>(requestDto);
            await unitOfWork.MarkRepository.Create(entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            await unitOfWork.MarkRepository.Delete(id, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<MarkResponse>> GetAll()
        {
            IEnumerable<Mark?> data = await unitOfWork.MarkRepository.ReadAll();
            IEnumerable<MarkResponse> response = mapper.Map<IEnumerable<MarkResponse>>(data);
            return response;
        }

        public async Task<MarkResponse> GetById(int id)
        {
            Mark? entity = await unitOfWork.MarkRepository.ReadById(x => x.Id.Equals(id), includeProperties: string.Empty);
            MarkResponse responseDto = mapper.Map<MarkResponse>(entity);
            return responseDto;
        }

        public async Task<bool> Update(int id, MarkRequest requestDto, CancellationToken cancellationToken)
        {
            Mark entity = mapper.Map<Mark>(requestDto);
            await unitOfWork.MarkRepository.Update(id, entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> ValidateNameId(int id, string name)
        {
            IEnumerable<Mark?> data = await unitOfWork.MarkRepository.ReadAll();
            IEnumerable<MarkResponse> response = mapper.Map<IEnumerable<MarkResponse>>(data);
            return GenericValidation.ValidateDuplicateNameField(response, id, name);
        }
    }
}
