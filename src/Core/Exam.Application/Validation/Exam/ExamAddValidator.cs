
namespace Exam.Application.Validation.Exam
{
    public class ExamAddValidator : AbstractValidator<ExamAddDTO>
    {
        public ExamAddValidator()
        {
            RuleFor(r=>r.ResultGrade).NotNull().WithMessage("This input cannot be empty")
                                     .GreaterThanOrEqualTo(1).WithMessage("The value can be between 1 and 5.")
                                     .LessThanOrEqualTo(10).WithMessage("The value can be between 1 and 5.");

            RuleFor(r=>r.LessonId).NotNull().WithMessage("This input cannot be empty");

            RuleFor(r=>r.StudentId).NotNull().WithMessage("This input cannot be empty");

            RuleFor(r => r.ExamDate).NotNull().WithMessage("This input cannot be empty");
        }
    }
}
