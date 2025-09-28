using Microsoft.AspNetCore.Mvc;
using TaqiaPortFolio.Data;
using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
      private readonly ApplicationDbContext _context;
        
        public SliderController(ApplicationDbContext context)
        {
             
            _context = context;
        
        }
        public IActionResult Index()
        {
            return View(_context.Slider.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id == 0) 
                return View(new Slider());
            else

            return View(_context.Slider.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Slider slider,List<IFormFile> ImageFile, List<IFormFile> CVfile)
        {
            foreach (var file in ImageFile)
            {
                if (file.Length > 0)
                {
                    string Image = Guid.NewGuid().ToString() + ".jpg";
                    var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads", Image);
                    using (var stream = System.IO.File.Create(FilePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    slider.Image = Image;
                }
                

            }
          
            foreach(var file in CVfile)
            {
                if (file.Length > 0)
                {
                    string CV = Guid.NewGuid().ToString() + ".pdf";
                    var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads", CV);
                    using (var stream = System.IO.File.Create(FilePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    slider.CV = CV;
                }
            }
                
            if (slider.Id == 0)
                _context.Slider.Add(slider);
            else
                _context.Slider.Update(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");

           
        }
        //public IActionResult Download(int id)
        //{
        //    var slider = _context.Slider.Find(id);
        //    if (slider == null || string.IsNullOrEmpty(slider.CV))
        //        return NotFound();
        //    var filePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/uploads",slider.CV);
        //    var fileByte=System.IO.File.ReadAllBytes(filePath);
        //    return File(fileByte,"application/pdf",slider.Name + ".pdf");
        //}
        public IActionResult Download(int id)
        {
            var slider = _context.Slider.Find(id);
            if (slider == null || string.IsNullOrEmpty(slider.CV))
                return NotFound();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", slider.CV);
            var fileByte = System.IO.File.ReadAllBytes(filePath);
            return File(fileByte, "application/pdf", slider.Name + " .pdf");

        }
        public IActionResult Delete(int id)
        {
            var slider = _context.Slider.Find(id);
            _context.Slider.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
