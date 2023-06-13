using FluentValidation;
using Models.Business;
using Models.Enums;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class ExtensionProjectPut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExtensionProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Course_ExtensionProject> Course_ExtensionProjects { get; set; }
        public virtual ICollection<Teacher_ExtensionProject> Teacher_ExtensionProjects { get; set; }
        public virtual ICollection<Student_ExtensionProject> Student_ExtensionProjects { get; set; }
    }

    public class ExtensionProjectPutValidation : AbstractValidator<ExtensionProjectPut>
    {
        public ExtensionProjectPutValidation()
        {
            RuleFor(v => v.Id)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Id"));

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

            RuleFor(v => v.Description)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Description"));
        }
    }
}
