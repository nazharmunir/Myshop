using Microsoft.AspNetCore.Mvc;
using Myshop.Models;

namespace Myshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDbContext _context;

        public HomeController(ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Detail(int ID)
        {
            var getval = _context.Products.Find(ID);
            if (getval != null)
            {
                return View(getval);
            }
            return Redirect("Index");
        }
        public IActionResult Delete(int ID)
        {
            var getval = _context.Products.Find(ID);
            if (getval != null)
            {
                _context.Products.Remove(getval);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public class ProductsController : Controller
        {
            private readonly ShopDbContext _context;

            public ProductsController(ShopDbContext context)
            {
                _context = context;
            }
  
         
        }
        }
    }

