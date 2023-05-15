using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Models.Business;
using Models.Enums;
using Models.Filters;
using Models.Infrastructure;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace Business.Services
{
    public class ProductService : BaseService<Product, int>, IProductService
    {

        private IEngelsCurveService _engelsCurveService;

        public ProductService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper, IEngelsCurveService engelsCurveService) : base(unitOfWork, mapper)
        {
            _engelsCurveService = engelsCurveService;
        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(ProductFilter filter)
        {
            var response = base.Search<TOutputModel>(
               filter.GetFilter(),
               include: source => source.Include(i => i.EngelsCurves.OrderBy(i => i.Income)),
               orderBy: null,
               filter.Page,
               filter.RowsPerPage
            );

            return response;
        }

        public override TOutputModel GetById<TOutputModel>(int Id)
        {
            return base.GetById<TOutputModel>(Id,
                include: source => source.Include(i => i.EngelsCurves));
        }

        public ProductResponse InsertAndClassificateProduct(ProductPost inputProduct)
        {
            Product product = Create<Product>(inputProduct);

            ProductResponse insertedProduct = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                EngelsCurvesResponse = new List<EngelsCurveResponse>()
            };

            EngelsCurveResponse lastCurve = null;

            inputProduct.EngelsCurvesPost.OrderBy(i => i.Income).ToList().ForEach(i =>
            {
                double angularCoefficient = 0;
                if (lastCurve != null)
                {
                    double deltaAmount = i.Amount - lastCurve.Amount;
                    double deltaIncome = i.Income - lastCurve.Income;
                    angularCoefficient = deltaAmount != 0 ? deltaIncome / deltaAmount : 0;
                }

                EngelsCurve engelsCurve = new EngelsCurve
                {
                    ProductId = insertedProduct.Id,
                    Income = i.Income,
                    Amount = i.Amount,
                    AngularCoefficient = angularCoefficient,
                    Classification = angularCoefficient >= 0 ? ProductClassification.StandardOrSuperior : ProductClassification.Inferior
                };

                lastCurve = _engelsCurveService.Create<EngelsCurveResponse>(engelsCurve);

                insertedProduct.EngelsCurvesResponse.Add(lastCurve);

            });

            AnalisysEngelsCurve(insertedProduct.EngelsCurvesResponse, ref product);

            insertedProduct.Observation = product.Observation;

            return insertedProduct;
        }

        private void AnalisysEngelsCurve(ICollection<EngelsCurveResponse> engelsCurves, ref Product product)
        {
            string observation = "";

            var secondItem = engelsCurves.OrderBy(i => i.Income).Skip(1).FirstOrDefault();

            if (secondItem.Classification.Equals(ProductClassification.StandardOrSuperior) && engelsCurves.Any(i => i.Classification.Equals(ProductClassification.Inferior)))
            {
                observation = "Este produto podemos observar que até certo ponto ele é normal/superior e depois ele se torna inferior. Esse caso é explicado pelo seguinte exemplo: <br/><br/>" +
                    "Uma determinada pessoa consome 5 unidades do chocolate A quando ganhava R$2.000,00 por mês, em seguida começou a consumir 10 unidades desse mesmo produto " +
                    "ao receber uma aumento salarial para R$ 3.000,00. Contudo tempos depois ela recebeu um aumento novamente para R$ 5.000,00 por mês e com esta renda, " +
                    "passou a ter acesso ao chocolate B e diminuiu o consumo do chocolate A. No caso o chocolate B é um produto superior ao chocolate A.";
            }
            else if (secondItem.Classification.Equals(ProductClassification.StandardOrSuperior) && !engelsCurves.Any(i => i.Classification.Equals(ProductClassification.Inferior) && i.AngularCoefficient != 0))
            {
                observation = "Podemos classificar esse produto como normal/superior, ou seja, quanto maior a renda, maior é a quantidade consumida do mesmo. As propriedades (Renda x Quantidade) tem relação direta!";
            }
            else if(secondItem.Classification.Equals(ProductClassification.Inferior) && !engelsCurves.Any(i => i.Classification.Equals(ProductClassification.StandardOrSuperior) && i.AngularCoefficient != 0))
            {
                observation = "Podemos classificar esse produto como inferior, ou seja, quanto maior a renda, menor é a quantidade consumida do mesmo. As propriedades (Renda x Quantidade) tem relação inversa!";
            }
            else
            {
                observation = "O software não conseguiu analisar esse produto!";
            }

            product.Observation = observation;

            Update<Product>(product);
        }
    }
}
