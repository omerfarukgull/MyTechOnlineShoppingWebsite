using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechBusiness.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetList();
        List<Product> GetAll(string search);
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(int productId);
    
        
    }
}
