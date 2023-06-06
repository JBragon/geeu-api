using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;
using Models.Enums;
using Models.Filters;
using Models.Infrastructure;

namespace Business.Services
{
    public class ExtensionProjectService : BaseService<ExtensionProject, int>, IExtensionProjectService
    {
        public ExtensionProjectService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(ExtensionProjectFilter filter)
        {
            var response = base.Search<TOutputModel>(
               filter.GetFilter(),
               include: null,
               orderBy: null,
               filter.Page,
               filter.RowsPerPage
            );

            return response;
        }

        public override TOutputModel Update<TOutputModel>(object entity)
        {
            var item = _mapper.Map<ExtensionProject>(entity);

            if (GetById<ExtensionProject>(item.Id).Status == ExtensionProjectStatus.Concluded)
                throw new Exception("Projeto concluído, não pode ser atualizado!");

            return base.Update<TOutputModel>(entity);

        }

        public override void Delete(int id)
        {
            ExtensionProject extensionProject = GetById<ExtensionProject>(id);

            if(extensionProject.Status != ExtensionProjectStatus.PendingApproval)
                throw new Exception("Projeto não pode ser excluído!");

            base.Delete(id);
        }
    }
}
