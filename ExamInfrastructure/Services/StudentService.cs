using Exam.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRoomService _classRoomService;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IClassRoomService classRoomService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _classRoomService = classRoomService;
        }
        public int Add(StudentAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Student>(addDTO);
                return _studentRepository.Add(entity);
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
                return _studentRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<StudentIndexDTO> GetAll()
        {
            try
            {
                var listIndexDto = _studentRepository.GetAll().Select(s => new StudentIndexDTO { Id=s.Id,Name = s.Name, LastName = s.LastName,Number=s.Number });
                return listIndexDto.ToList();
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public StudentAddDTO GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<StudentAddDTO>(_studentRepository.GetById(id));
                return dto;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public StudentAddDTO Initialize(StudentAddDTO model)
        {
            model.ClassRooms = _classRoomService.GetAll();
            return model;
        }

        public int Update(StudentAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Student>(addDTO);
                var result = _studentRepository.Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
