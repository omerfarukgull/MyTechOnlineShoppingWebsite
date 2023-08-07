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
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        private TechContext TechContext
        {
            get { return context as TechContext; }
        }
        public EfProductRepository(TechContext context) : base(context) { }


    }
}

