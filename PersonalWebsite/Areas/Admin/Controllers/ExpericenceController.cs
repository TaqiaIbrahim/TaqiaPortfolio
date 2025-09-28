using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpericenceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExpericenceController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Expericence.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id==0)
           return View(new Expericence());
            else
            return View(_context.Expericence.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Expericence expericence) {
            if (ModelState.IsValid)
            {
                if(expericence.Id==0)
                    _context.Expericence.Add(expericence);
                else
                    _context.Expericence.Update(expericence);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        return View(expericence);
        
        }
        public IActionResult Delete(int id)
        {
            var expericence = _context.Expericence.Find(id);
            _context.Expericence.Remove(expericence);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
