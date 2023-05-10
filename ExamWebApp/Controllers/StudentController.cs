using Exam.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var data = _studentService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = new StudentAddDTO();
            return View(_studentService.Initialize(data));
        }

        [HttpPost]
        public IActionResult Create(StudentAddDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var data = _studentService.Add(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _studentService.GetById(id);
            return View(_studentService.Initialize(data));
        }
        [HttpPost]
        public IActionResult Update(StudentAddDTO dto)
        {
            var data = _studentService.Update(dto);
            return RedirectToAction("Index");
        }
    }
}
