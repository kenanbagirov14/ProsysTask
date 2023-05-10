using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
    public class LessonIndexDTO : BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TeacherFullName { get; set; }
        public decimal ClassRoom { get; set; }

    }
}
