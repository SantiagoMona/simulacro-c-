using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using simulacro.Data;

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
    }
}