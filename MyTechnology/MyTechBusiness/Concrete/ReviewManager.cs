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

        public void Delete(int reviewId)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetAll(int productId)
        {
            return _reviewRepository.GetList(r => r.ProductId == productId);
        }

        public Review GetById(int reviewId)
        {
            throw new NotImplementedException();
        }

        public void Update(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
