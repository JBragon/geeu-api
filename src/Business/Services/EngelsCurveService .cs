using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Models.Business;
using Models.Filters;
using Models.Infrastructure;

namespace Business.Services
{
    public class EngelsCurveService : BaseService<EngelsCurve, int>, IEngelsCurveService
    {
        public EngelsCurveService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
