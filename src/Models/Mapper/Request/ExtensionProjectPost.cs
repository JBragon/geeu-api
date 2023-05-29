using FluentValidation;
using Models.Enums;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class ExtensionProjectPost
    {
        public string Name { get; set; }
        public ExtensionProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ExtensionProjectPostValidation : AbstractValidator<ExtensionProjectPost>
    {
        public ExtensionProjectPostValidation()
        {
            RuleFor(v => v.Name)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Name"))
              .MaximumLength(50);

            RuleFor(v => v.Status)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Status"));

            RuleFor(v => v.StartDate)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("StartDate"));
        }
    }
}
