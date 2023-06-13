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

        private readonly IExtensionProjectStatusLogService _extensionProjectStatusLogService;
        public ExtensionProjectService(
            IUnitOfWork<DBContext> unitOfWork, 
            IMapper mapper, IExtensionProjectStatusLogService extensionProjectStatusLogService) : base(unitOfWork, mapper)
        {
            _extensionProjectStatusLogService = extensionProjectStatusLogService;
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

        public override TOutputModel Create<TOutputModel>(object entity, string userName)
        {
            var item = _mapper.Map<ExtensionProject>(entity);

            item.Status = ExtensionProjectStatus.PendingApproval;
            item.ExtensionProjectStatusLogs = new List<ExtensionProjectStatusLog>();
            item.ExtensionProjectStatusLogs.Add(new ExtensionProjectStatusLog
            {
                Status = ExtensionProjectStatus.PendingApproval,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userName
            });

            return base.Create<TOutputModel>(item, userName);
        }

        public override TOutputModel Update<TOutputModel>(object entity, string userName)
        {
            var item = _mapper.Map<ExtensionProject>(entity);

            if (GetById<ExtensionProject>(item.Id).Status == ExtensionProjectStatus.Concluded)
                throw new Exception("Projeto concluído, não pode ser atualizado!");

            return base.Update<TOutputModel>(entity, userName);

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
