using Microsoft.EntityFrameworkCore;
using MyTechData.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Concrete.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechContext _context;
        public UnitOfWork(TechContext context)
        {
            _context = context;
        }
        private EfCartRepository _cartRepository;
        private EfProductRepository _productRepository;
        private EfCategoryRepository _categoryRepository;
        private EfOrderRepository _orderRepository;
        private EfReviewRepository _reviewRepository;
        public IProductRepository Products => _productRepository = _productRepository ?? new EfProductRepository(_context);

        public ICartRepository Carts =>  _cartRepository = _cartRepository ?? new EfCartRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCategoryRepository(_context);

        public IOrderRepository Orders  => _orderRepository = _orderRepository ?? new EfOrderRepository(_context);

        public IReviewRepository Reviews => _reviewRepository = _reviewRepository ?? new EfReviewRepository(_context);

        public void Dispose()
        {
           _context.Dispose();
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
