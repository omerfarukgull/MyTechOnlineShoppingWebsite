using Microsoft.AspNetCore.Mvc;
using MyTechBusiness.Abstract;

namespace MyTechWebUı.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int CategoryId)
        {
         
                var model = _productService.GetByCategory(CategoryId);
                return View(model);

        }
    }
}
