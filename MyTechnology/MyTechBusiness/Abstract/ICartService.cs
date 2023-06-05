using MyTechEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechBusiness.Abstract
{
    public interface ICartService
    {
        void InıtıalızeCart(string userId);
        void AddTooCart(string userId,int productId,int quantity);
        void DeleteFromCart(string userId,int productId);
        Cart GetCartByUserId(string userId);

    }
}
