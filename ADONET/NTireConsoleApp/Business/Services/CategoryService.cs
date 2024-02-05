using Business.Interfaces;
using Data.Entities;
using Data.Repositories;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }
        public void Add(Category t)
        {
            _categoryRepository.Add(t);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);

        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Update(Category t)
        {
            _categoryRepository.Update(t);
        }
    }
}
