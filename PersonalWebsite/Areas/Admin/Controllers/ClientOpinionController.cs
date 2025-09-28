using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientOpinionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientOpinionController(ApplicationDbContext context)
        {
            _context = context;
                
        }

        public IActionResult Index()
        {
            return View(_context.ClientOpinion.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
                return View(new ClientOpinion());
            else
            return View(_context.ClientOpinion.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(ClientOpinion clientOpinion)
        {
            if (ModelState.IsValid)
            {
                if (clientOpinion.Id == 0)
                    _context.ClientOpinion.Add(clientOpinion);
                else
                    _context.ClientOpinion.Update(clientOpinion);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientOpinion);
        }
        public IActionResult Delete(int id)
        {
            var clientOpinion = _context.ClientOpinion.Find(id);
            _context.ClientOpinion.Remove(clientOpinion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
