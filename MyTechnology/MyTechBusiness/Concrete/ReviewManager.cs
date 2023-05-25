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
    public class ReviewManager : IReviewService
    {
        private IReviewRepository _reviewRepository;
        public ReviewManager(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void Add(Review review)
        {
           _reviewRepository.Create(review);
        }

        public void Delete(Review review)
        {
            _reviewRepository.Delete(review);
        }
        public List<Review> GetAllWithProductName(string p)
        {
            return _reviewRepository.GetAllWithProductName(p);
        }
        public List<Review> GetAll(int productId)
        {
            return _reviewRepository.GetList(r => r.ProductId == productId);
        }

        public Review GetById(int reviewId)
        {
            return _reviewRepository.Get(r=>r.Id==reviewId);
        }

        public void Update(Review review)
        {
           _reviewRepository.Update(review);
        }

        public List<Review> GetAll()
        {
            return _reviewRepository.GetList();
        }
    }
}
