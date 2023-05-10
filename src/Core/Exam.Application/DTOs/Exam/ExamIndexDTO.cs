using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
    public class ExamIndexDTO : BaseDTO
    {
        public DateTime ExamDate { get; set; }
        public double ResultGrade { get; set; }
        public string LessonName { get; set; }
        public string StudentFullName { get; set; }
    }
}
