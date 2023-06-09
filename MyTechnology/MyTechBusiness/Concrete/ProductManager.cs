﻿using MyTechBusiness.Abstract;
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
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Create(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }
        public List<Product> GetList()
        {
            return _productRepository.GetList();
        }
        public List<Product> GetAll()
        {
            return _productRepository.GetList(p => p.IsApproved == true && p.IsHome == true);
        }

        public List<Product> GetAll(string search)
        {

            return _productRepository.GetList(p=>p.ProductName.Contains(search) && p.IsApproved == true && p.IsHome == true);
        }

        public List<Product> GetByCategory(int categoryId)
        {
        
            return _productRepository.GetList(p => p.CategoryId == categoryId || categoryId==0 && p.IsApproved == true && p.IsHome == true);
        }

        public Product GetById(int productId)
        {
            return _productRepository.Get(p=>p.ProductId==productId);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
