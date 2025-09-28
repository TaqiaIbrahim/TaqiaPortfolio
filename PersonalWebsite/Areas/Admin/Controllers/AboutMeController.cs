using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AboutMeController(ApplicationDbContext context)
        {
                _context= context;
        }
        public IActionResult Index()
        {
            var AboutMe = _context.AboutMe.ToList();
            return View(AboutMe);
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id==0)
                return View(new AboutMe());
            else
                return View(_context.AboutMe.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(AboutMe aboutMe,List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string Image = Guid.NewGuid().ToString() + ".jpg";
                    var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads", Image);
                    using (var stream = System.IO.File.Create(FilePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    aboutMe.Image = Image;
                }

            }
            if (aboutMe.Id == 0)
                _context.AboutMe.Add(aboutMe);
            else
                _context.AboutMe.Update(aboutMe);
            _context.SaveChanges();
            return RedirectToAction("Index");
          
        }
        public IActionResult Delete(int id)
        {
            var aboutMe=_context.AboutMe.Find(id);
            _context.AboutMe.Remove(aboutMe);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
