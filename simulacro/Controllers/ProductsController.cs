using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using simulacro.Data;
using simulacro.Models;

namespace simulacro.Controllers
{
    public class ProductsController : Controller
    {
        public readonly DBContext _dbContext;

        public ProductsController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Products.ToListAsync());
        }
        public async Task<IActionResult> Details(int id){
            return View(await _dbContext.Products.FindAsync(id));
        }
        public async Task<IActionResult> Delete(int? id){
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            _dbContext.Products.Add(p);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
    }
}