using FluentValidation;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class LoginPost
    {
        public string User { get; set; }
        public string Password { get; set; }
        public List<string> Attributes { get; private set; }

        public LoginPost()
        {
            Attributes = new List<string>
            {
                "primeironome",
                "ultimonome",
                "grupo",
                "email"
            };
        }
    }

    public class LoginPostValidation : AbstractValidator<LoginPost>
    {
        public LoginPostValidation()
        {
            RuleFor(v => v.User)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("User"))
              .IsValidCPF();

            RuleFor(v => v.Password)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Password"));
        }
    }
}
