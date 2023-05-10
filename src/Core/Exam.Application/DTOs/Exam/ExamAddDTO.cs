using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
    public class ExamAddDTO : BaseDTO
    {
        public ExamAddDTO()
        {
            Lessons = new List<LessonIndexDTO>();
            Students = new List<StudentIndexDTO>();
        }
        public DateTime ExamDate { get; set; }
        public decimal ResultGrade { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public ICollection<LessonIndexDTO> Lessons { get;set; }
        public ICollection<StudentIndexDTO> Students { get;set; }
    }

}
