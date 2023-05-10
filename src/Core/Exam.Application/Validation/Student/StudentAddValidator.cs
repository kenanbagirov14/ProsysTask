
namespace Exam.Application.Validation.Student
{
    public class StudentAddValidator : AbstractValidator<StudentAddDTO>
    {
        public StudentAddValidator()
        {
            RuleFor(r => r.Number).NotNull().WithMessage("This input cannot be empty");
            RuleFor(r=>r.Name).NotNull().WithMessage("This input cannot be empty")
                              .MaximumLength(30).WithMessage("You can write a maximum of 30 characters");
            RuleFor(r => r.LastName).NotNull().WithMessage("This input cannot be empty")
                              .MaximumLength(30).WithMessage("You can write a maximum of 30 characters");
            RuleFor(r => r.ClassRoomId).NotNull().WithMessage("This input cannot be empty");

        }
    }
}
