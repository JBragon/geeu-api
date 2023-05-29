using FluentValidation;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class CoursePost
    {
        public string Name { get; set; }
    }

    public class CoursePostValidation : AbstractValidator<CoursePost>
    {
        public CoursePostValidation()
        {
            RuleFor(v => v.Name)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Nome"))
              .MaximumLength(50);
        }
    }
}
