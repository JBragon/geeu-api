using FluentValidation;
using Models.Infrastructure;

namespace Models.Mapper.Request
{
    public class ProductPost
    {
        public string Name { get; set; }
        public string Registration { get; set; }

        public List<EngelsCurvePost> EngelsCurvesPost { get; set; }
    }

    public class ProductPostValidation : AbstractValidator<ProductPost>
    {
        public ProductPostValidation()
        {
            RuleFor(v => v.Name)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Nome"))
              .MaximumLength(50);

            RuleFor(v => v.Registration)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("'Matricula"))
              .MaximumLength(50)
              .Custom((registration, context) =>
              {

                  string[] registrations =
                  {
                        "paganini",
                        "21.1.8017",
                        "20.1.8022",
                        "21.1.8185",
                        "21.1.8189",
                        "20.2.8180",
                        "20.1.8038",
                        "21.1.8139",
                        "21.1.8128",
                        "21.1.8145",
                        "21.1.8124",
                        "20.2.8143",
                        "19.2.8102",
                        "19.2.8032",
                        "18.2.8027",
                        "21.1.8096",
                        "18.1.8050",
                        "20.2.8191",
                        "15.2.8176",
                        "21.1.8125",
                        "21.2.8158",
                        "20.2.8166",
                        "20.1.8015",
                        "21.1.8063",
                        "21.1.8044",
                        "21.1.8167",
                        "20.2.8153",
                        "21.1.8103",
                        "20.1.8106",
                        "19.1.8074",
                        "21.1.8148",
                        "17.1.8237",
                        "21.1.8043",
                        "22.2.8089",
                        "21.1.8038",
                        "18.1.1098",
                        "17.1.8343",
                        "20.2.8133"
                  };

                  if (!registrations.Contains(registration))
                  {
                      context.AddFailure("Matrícula Inválida!");
                  }

              });


            RuleFor(v => v.EngelsCurvesPost)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("Pontos da curva"))
              .Must(list => list.Count >= 2)
              .WithMessage("Deve possuir no mínimo duas coordenadas!")
              .Custom((list, context) =>
              {
                  if (list.GroupBy(p => new { p.Income, p.Amount }).Any(x => x.Count() > 1))
                  {
                      context.AddFailure("Não podem possuir coordenadas duplicadas!");
                  }

                  if (list.Any(e => e.Income < 0) || list.Any(e => e.Amount < 0))
                  {
                      context.AddFailure("Não podem possuir coordenadas negativas!");
                  }

                  if (list.Any(e => e.Income == 0 && e.Amount == 0))
                  {
                      context.AddFailure("Não é necessário informar o ponto (0, 0)!");
                  }
              });

        }
    }
}
