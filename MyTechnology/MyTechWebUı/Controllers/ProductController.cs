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
        public IActionResult Index(int categoryId)
        {
         
                var model = _productService.GetByCategory(categoryId);
                return View(model);

        }
    }
}
