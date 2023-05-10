using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.DTOs;


namespace ExamInfrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public int Add(TeacherAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Teacher>(addDTO);
                return _teacherRepository.Add(entity);
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
                return _teacherRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<TeacherIndexDTO> GetAll()
        {
            try
            {
                var listIndexDto = _teacherRepository.GetAll().Select(s => new TeacherIndexDTO { Id=s.Id,FirstName = s.FirstName, LastName = s.LastName });
                return listIndexDto.ToList();
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }

        }

        public TeacherAddDTO GetById(int id)
        {
            try
            {
                var dto = _mapper.Map<TeacherAddDTO>(_teacherRepository.GetById(id));
                return dto;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public int Update(TeacherAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Teacher>(addDTO);
                var result = _teacherRepository.Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
