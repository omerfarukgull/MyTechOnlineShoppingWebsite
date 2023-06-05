namespace MyTechWebUı.Models.CartModels
{
    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public int Quantity { get; set; }
    }
}