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
            throw new NotImplementedException();
        }

        public void Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetList();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
