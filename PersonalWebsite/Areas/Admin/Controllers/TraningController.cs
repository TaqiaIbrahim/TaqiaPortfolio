using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;
using System.Diagnostics.Eventing.Reader;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TrainingController( ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Training.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id == 0)
            
                return View(new Training());
                else
                    return View(_context.Training.Find(id));
            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Training Training)
        {
          if(ModelState.IsValid)
            {
                if(Training.Id==0)
                    _context.Training.Add(Training);
                else
                    _context.Training.Update(Training);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
          return View(Training);
        }
        public IActionResult Delete(int id) {
            var Training = _context.Training.Find(id);
            _context.Training.Remove(Training);
            _context.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}
