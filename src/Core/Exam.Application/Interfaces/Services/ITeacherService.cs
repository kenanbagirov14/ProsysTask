

namespace Exam.Application.Interfaces.Services
{
    public interface ITeacherService
    {
        public ICollection<TeacherIndexDTO> GetAll();
        public TeacherAddDTO GetById(int id);
        public int Add(TeacherAddDTO addDTO);
        public int Update(TeacherAddDTO addDTO);
        public int Delete(int id);
    }
}
