using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTechBusiness.Abstract;
using MyTechCore.Entities;
using MyTechEntity;
using MyTechWebUı.Identity;
using MyTechWebUı.Models;
using System.Reflection.Metadata;

namespace MyTechWebUı.Controllers
{
    [Authorize(Roles = "admin")]


    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IReviewService _reviewService;

        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AdminController(IProductService productService, ICategoryService categoryService, IReviewService reviewService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _reviewService = reviewService;
            _roleManager = roleManager;
            _userManager = userManager;
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
                    ProductName = product.ProductName,
                    ProductTitle = product.ProductTitle,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ImgUrl1 = file.FileName,
                    CategoryId = product.CategoryId,
                    IsApproved = product.IsApproved,
                    IsHome = product.IsHome,
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
        public IActionResult ProductEdit(int? productId)
        {
            var category = _categoryService.GetAll();
            List<SelectListItem> categoryValues = (from x in category
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categories = categoryValues;

            Product model = _productService.GetById((int)productId);
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

        [HttpPost]
        public IActionResult ProductDelete(int productId)
        {
            Product product = _productService.GetById(productId);
            if (product == null)
            {
                return NotFound();
            }
            _productService.Delete(product);
            return RedirectToAction("ProductList");
        }
        #endregion

        #region Kategori Islemleri
        public IActionResult CategoryList()
        {
            var model = _categoryService.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    CategoryName = categoryModel.CategoryName,
                };
                _categoryService.Add(entity);
                return RedirectToAction("CategoryList");
            }
            return View(categoryModel);

        }
        [HttpGet]
        public IActionResult CategoryDetails(int categoryId)
        {
            var entity = _categoryService.GetByIdProdcut(categoryId);
            var model = new CategoryModel
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Products = entity.Products.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryDetails(CategoryModel categoryModel)
        {
            var entity = _categoryService.GetById(categoryModel.CategoryId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.CategoryId = categoryModel.CategoryId;
            entity.CategoryName = categoryModel.CategoryName;
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }
        #endregion

        #region Yorum Islemeri
        public IActionResult ReviewList()
        {
            var model = _reviewService.GetAllWithProductName("Product");
            //var model = _reviewService.GetAll();
            return View(model);
        }
        public IActionResult ReviewDetails(int id)
        {
            var model = _reviewService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            var entity = new ReviewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Comment = model.Comment,
            };

            return View(entity);
        }
        [HttpPost]
        public IActionResult ReviewDetails(ReviewModel model)
        {
            var entity = _reviewService.GetById(model.Id);
            if (model == null)
            {
                return NotFound();
            }

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.Comment = model.Comment;
            _reviewService.Update(entity);

            return RedirectToAction("ReviewList");
        }
        [HttpPost]
        public IActionResult ReviewDelete(int reviewId)
        {
            var model = _reviewService.GetById(reviewId);
            if (model == null)
            {
                return NotFound();
            }
            _reviewService.Delete(model);
            return RedirectToAction("ReviewList");
        }
        #endregion

        #region Rol Islemleri
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RoleList));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> RoleEdit(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users.ToList())
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return Redirect("/admin/roleedit"+model.RoleId);
        }

        #endregion
    }
}
