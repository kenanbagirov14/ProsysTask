

using Exam.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Services
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        public ClassRoomService(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
        }

        public int Add(ClassRoomAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<ClassRoom>(addDTO);
                return _classRoomRepository.Add(entity);
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
                return _classRoomRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<ClassRoomIndexDTO> GetAll()
        {
            try
            {
                var listDto = _classRoomRepository.GetAll().Select(s=> new ClassRoomIndexDTO { Id=s.Id,Name =s.Name,Number=s.Number});
                return listDto.ToList();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ClassRoomAddDTO GetById(int id)
        {
            try
            {
                var entity = _classRoomRepository.GetById(id);
                return _mapper.Map<ClassRoomAddDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public int Update(ClassRoomAddDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<ClassRoom>(addDTO);
                return _classRoomRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
