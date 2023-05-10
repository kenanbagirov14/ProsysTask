
namespace Exam.Application.Interfaces.Services
{
    public interface IStudentService
    {
        public ICollection<StudentIndexDTO> GetAll();
        public StudentAddDTO GetById(int id);
        public int Add(StudentAddDTO addDTO);
        public int Update(StudentAddDTO addDTO);
        public int Delete(int id);
        public StudentAddDTO Initialize(StudentAddDTO model);
    }
}
