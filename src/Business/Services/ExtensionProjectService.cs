﻿using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Models.Business;
using Models.Enums;
using Models.Filters;
using Models.Infrastructure;
using Models.Mapper.Request;

namespace Business.Services
{
    public class ExtensionProjectService : BaseService<ExtensionProject, int>, IExtensionProjectService
    {

        public ExtensionProjectService(
            IUnitOfWork<DBContext> unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(ExtensionProjectFilter filter)
        {
            var response = base.Search<TOutputModel>(
               filter.GetFilter(),
               include: i => i.Include(v => v.ResponsibleUser),
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

            var extensionProject = GetById<ExtensionProject>(item.Id);

            if (extensionProject.Status == ExtensionProjectStatus.Concluded || extensionProject.Status == ExtensionProjectStatus.PermanentDisapproved)
                throw new Exception("Projeto não pode ser atualizado!");

            return base.Update<TOutputModel>(entity, userName);

        }

        public override void Delete(int id)
        {
            ExtensionProject extensionProject = GetById<ExtensionProject>(id);

            if (extensionProject.Status != ExtensionProjectStatus.PendingApproval)
                throw new Exception("Projeto não pode ser excluído!");

            base.Delete(id);
        }

        public SearchResponse<TOutputModel> GetExtensionProjectPendingApproval<TOutputModel>(GetExtensionProjectPendingApproval rows)
        {
            var filter = new ExtensionProjectFilter
            {
                Status = ExtensionProjectStatus.PendingApproval,
                RowsPerPage = rows.RowsPerPage,
                Page = rows.Page
            };

            return this.Search<TOutputModel>(filter);
        }
    }
}
