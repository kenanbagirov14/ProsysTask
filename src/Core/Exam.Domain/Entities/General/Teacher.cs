
namespace Exam.Domain.Entities
{
    public class Teacher : BaseEntity,ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Lesson Lesson { get; set; }
        
    }
}
