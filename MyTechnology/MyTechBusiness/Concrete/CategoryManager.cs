using MyTechBusiness.Abstract;
using MyTechData.Abstract;
using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechBusiness.Concrete
{
    public class CategoryManager: ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
           _categoryRepository.Create(category);
        }
        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetList();
        }

        public Category GetById(int categoryid)
        {
            return _categoryRepository.Get(c=>c.CategoryId==categoryid);
        }
        public Category GetByIdProdcut(int categoryid)
        {
            return _categoryRepository.GetByIdProdcut(categoryid);
        }
       
        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
