
namespace Exam.Application.Interfaces.Services
{
    public interface ILessonService
    {
        public ICollection<LessonIndexDTO> GetAll();
        public LessonAddDTO GetById(int id);
        public int Add(LessonAddDTO addDTO);
        public int Update(LessonAddDTO addDTO);
        public int Delete(int id);
        public LessonAddDTO Initialize(LessonAddDTO model);
    }
}
