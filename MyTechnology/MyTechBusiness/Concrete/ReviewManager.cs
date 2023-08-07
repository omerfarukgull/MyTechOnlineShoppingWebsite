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
        private IUnitOfWork _unitOfWork;
        public ReviewManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Review review)
        {
            _unitOfWork.Reviews.Create(review);
            _unitOfWork.Save();
        }

        public void Delete(Review review)
        {
            _unitOfWork.Reviews.Delete(review);
            _unitOfWork.Save();
        }
        public List<Review> GetAllWithProductName(string p)
        {
            return _unitOfWork.Reviews.GetAllWithProductName(p);
        }
        public List<Review> GetAll(int productId)
        {
            return _unitOfWork.Reviews.GetList(r => r.ProductId == productId);
        }

        public Review GetById(int reviewId)
        {
            return _unitOfWork.Reviews.Get(r=>r.Id==reviewId);
        }

        public void Update(Review review)
        {
            _unitOfWork.Reviews.Update(review);
            _unitOfWork.Save();
        }

        public List<Review> GetAll()
        {
            return _unitOfWork.Reviews.GetList();
        }
    }
}
