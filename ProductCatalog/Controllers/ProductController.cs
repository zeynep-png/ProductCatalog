using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product {Id =1, Name = "Laptop", Description = "Msi", Price = 1500},
            new Product {Id =2, Name = "Phone", Description = "Apple", Price = 150},
            new Product {Id =1, Name = "HeadPhones", Description = "JBL", Price = 65},

        };
        public IActionResult Index() //tüm ürünleri listeleyen action
        {
            return View(_products);
        }
        public IActionResult Details(int id) //ürün detaylarını gösteren action
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            return View(product); 
        } 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = _products.Max(x => x.Id) + 1;
            _products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(_ => _.Id == id);
            if (product != null)
                _products.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
