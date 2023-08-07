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
    public class EfCartRepository : EfGenericRepository<Cart>, ICartRepository
    {
        private TechContext TechContext
        {
            get { return context as TechContext; }
        }
        public EfCartRepository(TechContext context) : base(context) { }
        public void DeleteFromCart(int cartId, int productId)
        {

            var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
            TechContext.Database.ExecuteSqlRaw(cmd, cartId, productId);

        }

        public Cart GetByUserId(string userId)
        {

            return TechContext.Carts
                        .Include(i => i.CartItems)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault(i => i.UserId == userId);

        }
        public override void Update(Cart entity)
        {

            TechContext.Carts.Update(entity);

        }
    }
}
