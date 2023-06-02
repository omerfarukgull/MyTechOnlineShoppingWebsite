using Microsoft.AspNetCore.Mvc;
using MyTechBusiness.Abstract;
using MyTechEntity;
using MyTechWebUı.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace MyTechWebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categorytService;
        private IReviewService _reviewService;
        public HomeController(IProductService productService, ICategoryService categoryService, IReviewService reviewService)
        {
            _productService = productService;
            _categorytService = categoryService;
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int productId)
        {
            var model = new ProductDetailViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categorytService.GetAll(),
                Reviews = _reviewService.GetAll(productId)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Details(Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewService.Add(review);
                return RedirectToAction("Details", new RouteValueDictionary(
                                        new { controller = "Home", action = "Details", productId = review.ProductId }));
            }
            return View(review);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("User", mailRequest.ReceiverEmail);
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("Admin", "myblogtest10@gmail.com"); //Kime gidecek
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mailRequest.Body
            };

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("myblogtest10@gmail.com", "xiorqayjijnwtpos");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string? search)
        {
            ViewBag.Search = search;
            var model = _productService.GetAll(search);
            return View("Result", model);
        }
    }
}
