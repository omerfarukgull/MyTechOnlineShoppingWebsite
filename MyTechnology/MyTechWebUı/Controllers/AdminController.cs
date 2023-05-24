using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTechBusiness.Abstract;
using MyTechCore.Entities;
using MyTechEntity;
using MyTechWebUı.Models;
using System.Reflection.Metadata;

namespace MyTechWebUı.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Urun Islemleri
        public IActionResult ProductList()
        {
            var model = _productService.GetList();
            return View(model);
        }
        public IActionResult ProductAdd()
        {
            var category = _categoryService.GetAll();
            List<SelectListItem> categoryValues = (from x in category
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categories = categoryValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel product, IFormFile file)
        {
            if (product != null)
            {
                var entity = new Product
                {
                    ProductName=product.ProductName,
                    ProductTitle=product.ProductTitle,
                    ProductDescription=product.ProductDescription,
                    ProductPrice=product.ProductPrice,
                    ImgUrl1= file.FileName,
                    CategoryId=product.CategoryId,
                    IsApproved=product.IsApproved,
                    IsHome=product.IsHome,
                };
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                _productService.Add(entity);
                return RedirectToAction("ProductList");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult ProductEdit(int? ProductId)
        {
            var category = _categoryService.GetAll();
            List<SelectListItem> categoryValues = (from x in category
                                                   select new SelectListItem
                                                   {
                                                    Text=x.CategoryName,
                                                    Value=x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categories=categoryValues;

            Product model = _productService.GetById((int)ProductId);
            var entity = new ProductModel()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductTitle = model.ProductTitle,
                ImgUrl1 = model.ImgUrl1,
                ProductPrice = model.ProductPrice,
                CategoryId = model.CategoryId,
                IsApproved = model.IsApproved,
                IsHome = model.IsHome
            };
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel product, IFormFile file)
        {
            var entity = _productService.GetById(product.ProductId);
            if (entity == null)
            {
                return NotFound();
            }
            else if (entity != null && file != null)
            {
                entity.ProductName = product.ProductName;
                entity.ProductDescription = product.ProductDescription;
                entity.ProductTitle = product.ProductTitle;

                entity.ProductPrice = product.ProductPrice;
                entity.CategoryId = product.CategoryId;
                entity.IsApproved = product.IsApproved;
                entity.IsHome = product.IsHome;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entity.ImgUrl1 = file.FileName;
                _productService.Update(entity);
                return RedirectToAction("ProductList");
            }
            else if (entity != null)
            {
                entity.ProductName = product.ProductName;
                entity.ProductDescription = product.ProductDescription;
                entity.ProductTitle = product.ProductTitle;
                entity.ImgUrl1 = product.ImgUrl1;
                entity.ProductPrice = product.ProductPrice;
                entity.CategoryId = product.CategoryId;
                entity.IsApproved = product.IsApproved;
                entity.IsHome = product.IsHome;
                _productService.Update(entity);
                return RedirectToAction("ProductList");
            }
            return View(product);
        }
        #endregion

    }
}
