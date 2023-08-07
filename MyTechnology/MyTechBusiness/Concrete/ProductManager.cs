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
    public class ProductManager : IProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Product product)
        {
            _unitOfWork.Products.Create(product);
            _unitOfWork.Save();
        }

        public void Delete(Product product)
        {
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Save();
        }
        public List<Product> GetList()
        {
            return _unitOfWork.Products.GetList();
        }
        public List<Product> GetAll()
        {
            return _unitOfWork.Products.GetList(p => p.IsApproved == true && p.IsHome == true);
        }

        public List<Product> GetAll(string search)
        {

            return _unitOfWork.Products.GetList(p=>p.ProductName.Contains(search) && p.IsApproved == true && p.IsHome == true);
        }

        public List<Product> GetByCategory(int categoryId)
        {
        
            return _unitOfWork.Products.GetList(p => p.CategoryId == categoryId || categoryId==0 && p.IsApproved == true && p.IsHome == true);
        }

        public Product GetById(int productId)
        {
            return _unitOfWork.Products.Get(p=>p.ProductId==productId);
        }

        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
        }
    }
}
