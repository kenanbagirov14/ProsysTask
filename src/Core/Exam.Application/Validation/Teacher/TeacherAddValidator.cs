using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validation.Teacher
{
    public class TeacherAddValidator : AbstractValidator<TeacherAddDTO>
    {
        public TeacherAddValidator()
        {
            RuleFor(r => r.FirstName).NotNull().WithMessage("This input cannot be empty")
                              .MaximumLength(30).WithMessage("You can write a maximum of 30 characters");
            RuleFor(r => r.LastName).NotNull().WithMessage("This input cannot be empty")
                              .MaximumLength(30).WithMessage("You can write a maximum of 30 characters");
        }
    }
}
