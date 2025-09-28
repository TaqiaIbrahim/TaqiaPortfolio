using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
                return View(new Service());
            else
                return View(_context.Services.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Service service)
        {
            if(ModelState.IsValid)
            {
                if(service.Id==0)
                    _context.Services.Add(service);
                else
                    _context.Services.Update(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);
                _context.Services.Remove(service); 
                _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
