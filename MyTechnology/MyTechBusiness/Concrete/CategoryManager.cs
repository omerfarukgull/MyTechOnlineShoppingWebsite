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
        private IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Category category)
        {
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
        }
        public void Delete(Category category)
        {
            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Save();
        }

        public List<Category> GetAll()
        {
            return _unitOfWork.Categories.GetList();
        }

        public Category GetById(int categoryid)
        {
            return _unitOfWork.Categories.Get(c=>c.CategoryId==categoryid);
        }
        public Category GetByIdProdcut(int categoryid)
        {
            return _unitOfWork.Categories.GetByIdProdcut(categoryid);
        }
       
        public void Update(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }
    }
}
