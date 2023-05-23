using Microsoft.AspNetCore.Mvc;
using MyTechBusiness.Abstract;
using MyTechData.Abstract;

namespace MyTechWebUı.ViewComponents.Home
{
    public class ProductListViewComponent : ViewComponent
    {
        private IProductService _productService;
        public ProductListViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke(string? search)
        {
            var model = search == null ? _productService.GetAll() : _productService.GetAll(search);
            return View(model);
        }
    }
}
