
namespace Exam.Application.Validation.ClassRoom
{
    public class ClassRoomAddValidator : AbstractValidator<ClassRoomAddDTO>
    {
        public ClassRoomAddValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("This input cannot be empty")
                                .MaximumLength(30);
            RuleFor(x => x.Number).NotEmpty().WithMessage("This input cannot be empty")
                                  .NotNull().WithMessage("This input cannot be empty")
                                  .GreaterThanOrEqualTo(0)
                                  .LessThanOrEqualTo(99);

        }
    }
}
