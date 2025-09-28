using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Gallery.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
                return View(new Gallery());
            else
                return View(_context.Gallery.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult AddOrEdit(Gallery gallery, List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
               
                    var ext = Path.GetExtension(file.FileName);
                    string Image = Guid.NewGuid().ToString() + ext;
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads", Image);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                         file.CopyTo(stream);
                    }
                    gallery.Imagepath = Image;

                }

            }

            if (gallery.Id == 0)
                _context.Gallery.Add(gallery);
            else
                _context.Gallery.Update(gallery);
               _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 
          
       public IActionResult Delete(int id)
        {
            var gallery=_context.Gallery.Find(id);
            _context.Gallery.Remove(gallery);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
