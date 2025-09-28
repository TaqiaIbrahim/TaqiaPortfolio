using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
                
        }
        public IActionResult Index()
        {
            return View(_context.Skills.ToList());
        }
        public IActionResult AddOrEdit(int id )
        {
            if(id == 0) 
            return View(new Skills());
            else
                return View(_context.Skills.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Skills skills)
        {
            if (ModelState.IsValid)
            {
                if (skills.Id == 0)
                    _context.Skills.Add(skills);
                else
                    _context.Skills.Update(skills);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skills);
        }
        public IActionResult Delete(int id)
        {
            var skills = _context.Skills.Find(id);
            _context.Skills.Remove(skills);
            _context.SaveChanges(true);
            return RedirectToAction(nameof(Index));

        }
    }
}
