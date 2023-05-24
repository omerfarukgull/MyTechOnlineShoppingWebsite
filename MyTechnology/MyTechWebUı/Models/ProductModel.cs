using MyTechEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTechWebUı.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }
        [DisplayName("Ürün Başlık")]
        public string ProductTitle { get; set; }
        [DisplayName("Ürün Açıklama")]
        public string ProductDescription { get; set; }
        [DisplayName("Resim1")]
        public string ImgUrl1 { get; set; }
        public string? ImgUrl2 { get; set; }
        public string? ImgUrl3 { get; set; }
        [DisplayName("Ürün Fiyat")]
        public decimal ProductPrice { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
    
    }
}
