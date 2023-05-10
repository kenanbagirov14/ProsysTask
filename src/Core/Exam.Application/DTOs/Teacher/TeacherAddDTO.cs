using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
    public class TeacherAddDTO : BaseDTO
    {
        int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
