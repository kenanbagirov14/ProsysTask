using Exam.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var data = _teacherService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TeacherAddDTO());
        }

        [HttpPost]
        public IActionResult Create(TeacherAddDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var data = _teacherService.Add(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _teacherService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _teacherService.GetById(id);

            return View(data);
        }
        [HttpPost]
        public IActionResult Update(TeacherAddDTO dto)
        {
            var data = _teacherService.Update(dto);
            return RedirectToAction("Index");
        }
    }
}
