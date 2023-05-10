
namespace Exam.Domain.Entities
{
    public class Student : BaseEntity,ISoftDelete
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Number { get; set; }
        public bool IsDeleted { get; set; }
        public int ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
