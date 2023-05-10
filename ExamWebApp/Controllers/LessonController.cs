using Exam.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public IActionResult Index()
        {
            var data = _lessonService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = new LessonAddDTO();
            return View(_lessonService.Initialize(data));
        }

        [HttpPost]
        public IActionResult Create(LessonAddDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var data = _lessonService.Add(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _lessonService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _lessonService.GetById(id);
            return View(_lessonService.Initialize(data));
        }
        [HttpPost]
        public IActionResult Update(LessonAddDTO dto)
        {
            var data = _lessonService.Update(dto);
            return RedirectToAction("Index");
        }
    }
}
