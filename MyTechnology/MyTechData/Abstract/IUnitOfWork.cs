using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICartRepository Carts { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IReviewRepository Reviews { get; }
        void Save();
    }
}
