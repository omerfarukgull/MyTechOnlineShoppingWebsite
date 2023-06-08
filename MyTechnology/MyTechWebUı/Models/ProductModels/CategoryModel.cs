using MyTechEntity;
using System.ComponentModel;

namespace MyTechWebUı.Models.ProductModels
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
