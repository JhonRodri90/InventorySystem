using AutoMapper;
using BusinessLogic.Contracts;
using Context.Entities;
using DataTransferObjets.Dto.In;
using DataTransferObjets.Dto.Out;
using Repository.GenericRepository.Interfaces;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(CategoryRequest requestDto, CancellationToken cancellationToken)
        {
            Category entity = mapper.Map<Category>(requestDto);
            await unitOfWork.CategoryRepository.Create(entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            await unitOfWork.CategoryRepository.Delete(id, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAll()
        {
            IEnumerable<Category?> data = await unitOfWork.CategoryRepository.ReadAll();
            IEnumerable<CategoryResponse> response = mapper.Map<IEnumerable<CategoryResponse>>(data);
            return response;
        }

        public async Task<CategoryResponse> GetById(int id)
        {
            Category? entity = await unitOfWork.CategoryRepository.ReadById(x => x.Id.Equals(id), includeProperties: string.Empty);
            CategoryResponse responseDto = mapper.Map<CategoryResponse>(entity);
            return responseDto;
        }

        public async Task<bool> Update(int id, CategoryRequest requestDto, CancellationToken cancellationToken)
        {
            Category entity = mapper.Map<Category>(requestDto);
            await unitOfWork.CategoryRepository.Update(id, entity, cancellationToken);
            int result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
