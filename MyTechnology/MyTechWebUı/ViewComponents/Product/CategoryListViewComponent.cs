using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyTechBusiness.Abstract;

namespace MyTechWebUı.ViewComponents.Product
{
    public class CategoryListViewComponent: ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _categoryService.GetAll();
            return View(model);
        }
    }
}
