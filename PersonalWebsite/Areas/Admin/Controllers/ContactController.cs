using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController( ApplicationDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            return View(_context.Contacts.ToList());
        }
        public IActionResult Delete(int id )
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }
    }
}
