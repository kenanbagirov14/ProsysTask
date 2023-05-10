
namespace Exam.Domain.Entities
{

    public class ClassRoom : BaseEntity, ISoftDelete
    {
        public decimal Number { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
