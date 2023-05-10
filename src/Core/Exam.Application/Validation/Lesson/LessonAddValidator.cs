
namespace Exam.Application.Validation.Lesson
{
    public class LessonAddValidator : AbstractValidator<LessonAddDTO>
    {
        public LessonAddValidator()
        {

            RuleFor(r => r.Code).NotNull().WithMessage("This input cannot be empty")
                                          .MaximumLength(3).WithMessage("You can write a maximum of 3 characters");

            RuleFor(r => r.Name).NotNull().WithMessage("This input cannot be empty")
                                          .MaximumLength(30).WithMessage("You can write a maximum of 30 characters");

            RuleFor(r => r.TeacherId).NotNull().WithMessage("This input cannot be empty");

        }
    }
}
