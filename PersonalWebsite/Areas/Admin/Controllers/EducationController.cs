using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EducationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Education.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
                return View(new Education());
            else
                return View(_context.Education.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Education education)
        {

            if (ModelState.IsValid)
            {
                if (education.Id == 0)
                    _context.Education.Add(education);
                else
                    _context.Education.Update(education);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(education);
        }


        public IActionResult Delete(int id)
        {
            var education = _context.Education.Find(id);
            _context.Education.Remove(education);
            _context.SaveChanges();
          return RedirectToAction("Index");
        }
    }
    }

