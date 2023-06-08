using MyTechEntity;

namespace MyTechWebUı.Models.ProductModels
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
