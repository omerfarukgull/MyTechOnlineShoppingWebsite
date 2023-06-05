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
    public class EfCartRepository : EfGenericRepository<Cart, TechContext>, ICartRepository
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var ctx = new TechContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
                ctx.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var ctx = new TechContext())
            {
                return ctx.Carts
                            .Include(i => i.CartItems)
                            .ThenInclude(i => i.Product)
                            .FirstOrDefault(i => i.UserId == userId);
            }
        }
        public override void Update(Cart entity)
        {
            using (var context = new TechContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
