using FluentValidation;
using Models.Business;
using Models.Enums;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class ExtensionProjectPost
    {
        public int ResponsibleUserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Course_ExtensionProjectPost> Course_ExtensionProjects { get; set; }
        public virtual ICollection<Teacher_ExtensionProjectPost> Teacher_ExtensionProjects { get; set; }
    }

    public class ExtensionProjectPostValidation : AbstractValidator<ExtensionProjectPost>
    {
        public ExtensionProjectPostValidation()
        {
            RuleFor(v => v.ResponsibleUserId)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("ResponsibleUserId"));

            RuleFor(v => v.Name)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Name"))
              .MaximumLength(50);

            RuleFor(v => v.StartDate)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("StartDate"));

            RuleFor(v => v.Description)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Description"));

            RuleFor(v => v.Course_ExtensionProjects)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Course_ExtensionProjects"));

            RuleFor(v => v.Teacher_ExtensionProjects)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Teacher_ExtensionProjects"));
        }
    }
}
