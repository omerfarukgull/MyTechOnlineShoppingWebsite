using MyTechEntity;

namespace MyTechWebUı.Models
{
    public class ProductDetailViewModel
    {
        public Product? Product { get; set; }
        public List<Category>? Categories { get; set; }
        public Category Category { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public Review Review { get; set; }
    }
}
