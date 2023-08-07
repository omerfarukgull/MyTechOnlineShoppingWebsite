using Microsoft.EntityFrameworkCore;
using MyTechData.Abstract;
using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Concrete.Ef
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        private TechContext TechContext
        {
            get { return context as TechContext; }
        }
        public EfCategoryRepository(TechContext context) : base(context) { }

        public Category GetByIdProdcut(int categoryid)
        {
           
                return TechContext.Categories
                        .Where(i => i.CategoryId == categoryid)
                        .Include(i=>i.Products)
                        .FirstOrDefault();
            
        }
    }
}
