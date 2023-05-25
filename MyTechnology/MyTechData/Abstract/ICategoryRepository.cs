using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdProdcut(int categoryid);

    }
}
