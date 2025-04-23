using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        // GET: TeacherController
        public ActionResult Index()
        {
            return View(_teacherService.GetList());
        }
        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher, IFormFile? Image)
        {
            try
            {
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(klasor, FileMode.Create);
                Image.CopyTo(stream);
                teacher.Image = Image.FileName;
                _teacherService.Add(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_teacherService.GetByID(id));
        }
        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher, IFormFile? Image)
        {
            try
            {
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(klasor, FileMode.Create);
                Image.CopyTo(stream);
                teacher.Image = Image.FileName;
                _teacherService.Update(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)  // tek bir kayıt kladığı zaman sorun yaratabiliyor tam çözümü ajax kullanımıdır.
        {
            try
            {
                var silinecekId = _teacherService.GetByID(id);
                _teacherService.Delete(silinecekId);
                return RedirectToAction("Index"); // Silme işlemi başarılıysa Index sayfasına yönlendir
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return StatusCode(500); // İsteği işlerken bir hata oluşursa 500 Internal Server Error dön
            }
        }
    }
}
