
namespace Exam.Domain.Entities
{
    public class Exam : BaseEntity, ISoftDelete
    {
        public DateTime ExamDate { get; set; }
        public double ResultGrade { get; set; }
        public bool IsDeleted { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
