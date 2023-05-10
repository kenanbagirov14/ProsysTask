using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
    public class LessonAddDTO : BaseDTO
    {
        public LessonAddDTO()
        {
            Teachers = new List<TeacherIndexDTO>();
            ClassRooms = new List<ClassRoomIndexDTO>();
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int ClassRoomId { get; set; }

        public ICollection<TeacherIndexDTO> Teachers { get; set; }
        public ICollection<ClassRoomIndexDTO> ClassRooms { get; set; }
    }
}
