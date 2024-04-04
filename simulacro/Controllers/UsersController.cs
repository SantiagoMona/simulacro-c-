using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simulacro.Data;
using simulacro.Models;

namespace simulacroid.Controllers
{
    public class UsersController : Controller
    {
        public readonly DBContext _context;
        public UsersController(DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string buscar){
            var usuarios = from usuario in _context.Users select usuario;

            if (!string.IsNullOrEmpty(buscar))
            {
                usuarios = usuarios.Where(s=>s.Name!.Contains(buscar) || s.LastName!.Contains(buscar));
            }

            return View(await usuarios.ToListAsync());
        }
        public async Task<IActionResult> Details(int id){
            return View(await _context.Users.FindAsync(id));
        }
        public async Task<IActionResult> Delete(int? id){
            var user = await _context.Users.FindAsync(id);
           
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    
        // ACCIONES PARA REGISTRAR EN LA BASE DE DATOS
         [HttpPost]
        public IActionResult Create(User u)// DE EL MODELO USER SE LE ASIGNA TODO ALA VARIABLE "u"
        {
            _context.Users.Add(u);//EN ESTA LINEA DE CODIGO SE AGREGA ALA BASE DE DATOS

            _context.SaveChanges();// SE GUARDA TODO EN LA BASE DE DATOS

            return RedirectToAction(nameof(Index));//REDIRECCIONAMOS ALA PAGINA PRINCIPAL

        }

        //editar 
        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _context.Users.FirstOrDefaultAsync(m=>m.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User u)
        {
            _context.Users.Update(u);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}