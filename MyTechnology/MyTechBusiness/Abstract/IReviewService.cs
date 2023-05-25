using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechBusiness.Abstract
{
    public interface IReviewService
    {
        List<Review> GetAll(int productId);
        List<Review> GetAll();
        List<Review> GetAllWithProductName(string p);
        Review GetById(int reviewId);
        void Add(Review review);
        void Update(Review review);
        void Delete(Review review);
    }
}
