using Microsoft.EntityFrameworkCore;
using MyTechCore.Entities;
using MyTechData.Abstract;
using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Concrete.Ef
{
    public class EfReviewRepository : EfGenericRepository<Review, TechContext>, IReviewRepository
    {
        public List<Review> GetAllWithProductName(string p)
        {
            using (var context = new TechContext())
            {
                return context.Reviews.Include(p).ToList();
            }
        }
    }
}
