using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Models;
using TaqiaPortFolio.ViewModel;
using System.Diagnostics;
using TaqiaPortFolio.Data;

namespace TaqiaPortFolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context= context;
        }

        public IActionResult Index()
        {
            var ViewModel = new formViewModel
            {
                aboutMe = _context.AboutMe.ToList().Take(1),
                experiences=_context.Expericence.ToList(),
                educations=_context.Education.ToList(),
                services=_context.Services.ToList(),
                skills=_context.Skills.ToList(),
                clientOpinion= _context.ClientOpinion.ToList(),
                Training=_context.Training.ToList(),
                Sliders=_context.Slider.ToList().Take(1),
                Galleries=_context.Gallery.ToList(),
            };
         
         
            return View(ViewModel);
        }
        public IActionResult Download(int id)
        {
            var slider = _context.Slider.Find(id);
            if (slider == null || string.IsNullOrEmpty(slider.CV))
                return NotFound();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", slider.CV);
            var fileByte = System.IO.File.ReadAllBytes(filePath);
            return File(fileByte, "application/pdf", slider.Name + ".pdf");

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


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}