using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechBusiness.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
    }
}
