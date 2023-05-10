using Exam.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public IActionResult Index()
        {
            var data = _examService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = new ExamAddDTO();
            return View(_examService.Initialize(data));
        }

        [HttpPost]
        public IActionResult Create(ExamAddDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var data = _examService.Add(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _examService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _examService.GetById(id);
            return View(_examService.Initialize(data));
        }
        [HttpPost]
        public IActionResult Update(ExamAddDTO dto)
        {
            var data = _examService.Update(dto);
            return RedirectToAction("Index");
        }
    }
}
