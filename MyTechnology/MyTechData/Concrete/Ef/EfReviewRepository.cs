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
    public class EfReviewRepository : EfGenericRepository<Review>, IReviewRepository
    {
        private TechContext TechContext
        {
            get { return context as TechContext; }
        }
        public EfReviewRepository(TechContext context) : base(context) { }
        public List<Review> GetAllWithProductName(string p)
        {

            return TechContext.Reviews.Include(p).ToList();

        }
    }
}
