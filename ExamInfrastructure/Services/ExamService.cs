using Exam.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        public ExamService(IExamRepository examRepository, IMapper mapper, IStudentService studentService, ILessonService lessonService)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _studentService = studentService;
            _lessonService = lessonService;
        }
        public int Add(ExamAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Exam.Domain.Entities.Exam>(addDTO);
                return _examRepository.Add(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }

        }

        public int Delete(int id)
        {
            try
            {
                return _examRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<ExamIndexDTO> GetAll()
        {
            try
            {
                var value = _examRepository.GetAll().Include(s=>s.Lesson).Include(s=>s.Student).Select(s => new ExamIndexDTO
                {
                    Id= s.Id,
                    ResultGrade = s.ResultGrade,
                    ExamDate = s.ExamDate,
                    LessonName = s.Lesson.Name,
                    StudentFullName = s.Student.Name
                });
                return value.ToList();

            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ExamAddDTO GetById(int id)
        {
            try
            {
                var entity = _examRepository.GetById(id);
                return _mapper.Map<ExamAddDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ExamAddDTO Initialize(ExamAddDTO model)
        {
            model.Lessons = _lessonService.GetAll();
            model.Students = _studentService.GetAll();

           return model;
        }

        public int Update(ExamAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Exam.Domain.Entities.Exam>(addDTO);
                return _examRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
