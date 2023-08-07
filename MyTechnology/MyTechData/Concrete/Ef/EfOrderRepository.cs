using MyTechData.Abstract;
using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Concrete.Ef
{
    public class EfOrderRepository:EfGenericRepository<Order>,IOrderRepository
    {
        private TechContext TechContext
        {
            get { return context as TechContext; }
        }
        public EfOrderRepository(TechContext context) : base(context) { }
    }
}
