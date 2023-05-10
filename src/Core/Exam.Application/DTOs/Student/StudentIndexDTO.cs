using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
    public class StudentIndexDTO : BaseDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Number { get; set; }
        public decimal ClassRoomNumber { get; set; }
    }
}
