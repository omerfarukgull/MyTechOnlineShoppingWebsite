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
        Review GetById(int reviewId);
        void Add(Review review);
        void Update(Review review);
        void Delete(int reviewId);
    }
}
