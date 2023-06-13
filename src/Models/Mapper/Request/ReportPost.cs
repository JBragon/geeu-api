using FluentValidation;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class ReportPost
    {
        public int ExtensionProjectId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }

    public class ReportPostValidation : AbstractValidator<ReportPost>
    {
        public ReportPostValidation()
        {
            RuleFor(v => v.ExtensionProjectId)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("ExtensionProjectId"));

            RuleFor(v => v.UserId)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("UserId"));

            RuleFor(v => v.Description)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("UserId"));
        }
    }
}
