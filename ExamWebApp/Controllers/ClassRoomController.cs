global using Exam.Application.Interfaces.Services;
using Exam.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        public IActionResult Index()
        {
            var data = _classRoomService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ClassRoomAddDTO());
        }

        [HttpPost]
        public IActionResult Create(ClassRoomAddDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var data = _classRoomService.Add(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _classRoomService.Delete(id);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _classRoomService.GetById(id);

            return View(data);
        }
        [HttpPost]
        public IActionResult Update(ClassRoomAddDTO dto)
        {
            var data = _classRoomService.Update(dto);
            return RedirectToAction("Index");
        }
    }
}
