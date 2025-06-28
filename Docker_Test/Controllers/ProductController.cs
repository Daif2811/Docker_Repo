using Docker_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Docker_Test.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Products.ToList();
            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        


        public IActionResult Update(int id)
        {
            var result = _context.Products.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _context.Products.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            _context.Products.Remove(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
