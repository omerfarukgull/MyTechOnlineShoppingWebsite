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
    public class EfCategoryRepository : EfGenericRepository<Category, TechContext>, ICategoryRepository
    {
        public Category GetByIdProdcut(int categoryid)
        {
            using (var context = new TechContext())
            {
                return context.Categories
                        .Where(i => i.CategoryId == categoryid)
                        .Include(i=>i.Products)
                        .FirstOrDefault();
            }
        }
    }
}
