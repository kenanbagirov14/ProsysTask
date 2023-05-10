
namespace Exam.Domain.Entities
{
    public class Lesson : BaseEntity , ISoftDelete
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
