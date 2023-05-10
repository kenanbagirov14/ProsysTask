using Exam.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lesson;
        private readonly IClassRoomService _classRoomService;
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public LessonService(ILessonRepository lesson, IMapper mapper, IClassRoomService classRoom, ITeacherService teacher)
        {
            _lesson = lesson;
            _mapper = mapper;
            _classRoomService = classRoom;
            _teacherService = teacher;
        }

        public int Add(LessonAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Lesson>(addDTO);
                return _lesson.Add(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message);
            }
        }

        public int Delete(int id)
        {
            try
            {
                return _lesson.Delete(id);
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<LessonIndexDTO> GetAll()
        {
            try
            {
                var listIndexDto = _lesson.GetAll().Include(s=>s.Teacher).Include(s=>s.ClassRoom).Select(s => new LessonIndexDTO { Id=s.Id,Code = s.Code, Name = s.Name,TeacherFullName = s.Teacher.FirstName,ClassRoom=s.ClassRoom.Number });
                return listIndexDto.ToList();
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public LessonAddDTO GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<LessonAddDTO>(_lesson.GetById(id));
                return dto;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public LessonAddDTO Initialize(LessonAddDTO model)
        {
            model.ClassRooms = _classRoomService.GetAll();
            model.Teachers = _teacherService.GetAll();
           return model;
        }

        public int Update(LessonAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Lesson>(addDTO);
                var result = _lesson.Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
