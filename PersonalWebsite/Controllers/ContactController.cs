using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;
using TaqiaPortFolio.ViewModel;

namespace TaqiaPortFolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController( ApplicationDbContext context)
        {
           
            _context = context;
        }
        public IActionResult Add(int id)
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Contact contact)
        {
            var viewModel = new formViewModel
            {
                Name = contact.Name,
                Subject = contact.Subject,
                Email = contact.Email,
                Message = contact.Message,
            };
            if (ModelState.IsValid)
            {
                if (contact.Id == 0)
                    _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}


