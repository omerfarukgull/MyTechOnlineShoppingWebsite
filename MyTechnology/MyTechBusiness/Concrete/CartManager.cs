using MyTechBusiness.Abstract;
using MyTechData.Abstract;
using MyTechEntity;

namespace MyTechBusiness.Concrete
{
    public class CartManager : ICartService
    {
        private IUnitOfWork _unitOfWork;
        public CartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTooCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var result = cart.CartItems.FindIndex(i=>i.ProductId==productId);
                if (result<0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        Quantity= quantity,
                        CartId= cart.Id
                    });
                }
                else
                {
                    cart.CartItems[result].Quantity+= quantity;
                }
                _unitOfWork.Carts.Update(cart);
                _unitOfWork.Save();
            }
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null) 
            {
                _unitOfWork.Carts.DeleteFromCart(cart.Id,productId);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            return _unitOfWork.Carts.GetByUserId(userId);
        }

        public void InıtıalızeCart(string userId)
        {
            _unitOfWork.Carts.Create(new Cart() { UserId = userId });
        }
    }
}
