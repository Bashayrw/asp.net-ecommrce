using AutoMapper;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryReadDto> CreateOne(CategoryCreateDto newCategory)
        {
            Category category = _mapper.Map<Category>(newCategory);
            var categoryList = _categoryRepository.CreateOne(category);
            var mappedCategoryList = categoryList.Select(_mapper.Map<CategoryReadDto>);
            return mappedCategoryList;
        }

        public IEnumerable<CategoryReadDto> FindMany()
        {
            Console.WriteLine($"In service");
            IEnumerable<Category> categories = _categoryRepository.FindMany();
            return categories.Select(_mapper.Map<CategoryReadDto>);
        }


        public Category? FindOne(Guid categoryId)
        {
            return _categoryRepository.FindOne(categoryId);
        }


        public Category UpdateOne(Guid categoryId, Category updatedCategory)
        {
            return _categoryRepository.UpdateOne(categoryId, updatedCategory);
        }

        public IEnumerable<Category>? DeleteCategory(Guid categoryId)
        {
            return _categoryRepository.DeleteCategory(categoryId);
        }
    }
}