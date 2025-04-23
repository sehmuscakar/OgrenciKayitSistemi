using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public StudentController(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(_studentService.GetAllStudents());
        }


        // GET: StudentController/Create
        public ActionResult Create()
        {
            // Öğretmen listesini getir
            var teachers = _teacherService.GetList()
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Ad + " " + t.Soyad
                }).ToList();

            // ViewBag üzerinden View'e gönder
            ViewBag.TeacherId = teachers;

            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, IFormFile? Image)
        {
            try
            {
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(klasor, FileMode.Create);
                Image.CopyTo(stream);
                student.Image = Image.FileName;
                _studentService.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_studentService.GetByID(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student, IFormFile? Image)
        {
            try
            {
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(klasor, FileMode.Create);
                Image.CopyTo(stream);
                student.Image = Image.FileName;
                _studentService.Update(student);
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
                var silinecekId = _studentService.GetByID(id);
                _studentService.Delete(silinecekId);
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
