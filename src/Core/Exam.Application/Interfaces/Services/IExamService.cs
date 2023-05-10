
namespace Exam.Application.Interfaces.Services
{
    public interface IExamService
    {
        public ICollection<ExamIndexDTO> GetAll();
        public ExamAddDTO GetById(int id);
        public int Add(ExamAddDTO addDTO);
        public int Update(ExamAddDTO addDTO);
        public int Delete(int id);
        public ExamAddDTO Initialize(ExamAddDTO model);
    }
}
