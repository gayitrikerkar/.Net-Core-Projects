using ImageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageApp.Controllers
{ 
    public class ProductController : Controller
    {
        private readonly ImageAppContext _imageAppContext;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(ImageAppContext imageAppContext, IWebHostEnvironment webHostEnvironment)
        {
            _imageAppContext = imageAppContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_imageAppContext.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductView productView)
        {
            string fileName = string.Empty;
            if (productView.Photo != null)
            {
                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + productView.Photo.FileName;
                string filePath = Path.Combine(folder, fileName);
                productView.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                Product p = new Product()
                {
                    Name = productView.Name,
                    Price = productView.Price,
                    ImagePath = fileName,
                };
                _imageAppContext.Products.Add(p);
                _imageAppContext.SaveChanges();
                TempData["Success"] = "Product added";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
