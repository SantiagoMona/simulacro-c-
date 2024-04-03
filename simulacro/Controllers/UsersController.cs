using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simulacro.Data;

namespace simulacroid.Controllers
{
    public class UsersController : Controller
    {
        public readonly DBContext _context;
        public UsersController(DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.Users.ToListAsync());
        }
        public async Task<IActionResult> Details(int id){
            return View(await _context.Users.FindAsync(id));
        }
    }
}