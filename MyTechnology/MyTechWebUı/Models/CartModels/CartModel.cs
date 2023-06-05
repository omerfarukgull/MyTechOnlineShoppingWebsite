namespace MyTechWebUı.Models.CartModels
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }

        public decimal TotalPrice()
        {
            return CartItems.Sum(i => i.Price*i.Quantity);
        }
    }
}
