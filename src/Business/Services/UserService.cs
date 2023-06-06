using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Models.Business;
using Models.Infrastructure;
using System.Linq.Expressions;

namespace Business.Services
{
    public class UserService : IUserService
    {
        protected readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Properties
        protected readonly IUnitOfWork _unitOfWork;
        private IRepository<User> repository;

        protected IRepository<User> Repository
        {
            get
            {
                if (repository == null)
                {
                    repository = _unitOfWork.GetRepository<User>();
                }
                return repository;
            }
        }

        #endregion

        public virtual TOutputModel Create<TOutputModel>(object inputModel)
        {
            var entity = _mapper.Map<User>(inputModel);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            Repository.Insert(entity);
            _unitOfWork.SaveChanges();

            return _mapper.Map<TOutputModel>(entity);
        }

        public virtual TOutputModel GetById<TOutputModel>(int Id)
        {
            var outputModel = GetById<TOutputModel>(Id, null);

            return outputModel;
        }

        public virtual TOutputModel Update<TOutputModel>(object entity)
        {
            var item = _mapper.Map<User>(entity);

            item.UpdatedAt = DateTime.Now;

            Repository.Update(item);
            _unitOfWork.SaveChanges();

            return _mapper.Map<TOutputModel>(item);

        }

        //public virtual async Task Delete(TPrimarykey id)
        public virtual void Delete(int id)
        {
            var entity = Repository.GetFirstOrDefault(predicate: v => v.Id.Equals(id));
            Repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual bool Exist(int Id)
        {
            return Repository.GetFirstOrDefault(predicate: v => v.Id.Equals(Id)) != null;
        }

        protected virtual SearchResponse<User> Search(Expression<Func<User, bool>> filter,
                                                      Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null,
                                                      Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
                                                      int pageIndex = 0,
                                                      int pageSize = 10)
        {
            var response = Repository.GetPagedList(
                filter,
                include: include,
                orderBy: orderBy,
                pageIndex: pageIndex,
                pageSize: pageSize
                );

            return new SearchResponse<User>()
            {
                Items = response.Items,
                RowsCount = response.TotalCount,
                PageIndex = response.PageIndex
            };
        }

        protected virtual SearchResponse<TOutputModel> Search<TOutputModel>(Expression<Func<User, bool>> filter,
                                                      Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null,
                                                      Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
                                                      int pageIndex = 0,
                                                      int pageSize = 10)
        {
            var response = Search(filter, include, orderBy, pageIndex, pageSize);
            return new SearchResponse<TOutputModel>(_mapper.Map<IEnumerable<TOutputModel>>(response.Items), response.RowsCount, response.PageIndex);
        }


        protected virtual TOutputModel GetById<TOutputModel>(int Id, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null)
        {
            var entity = Repository.GetFirstOrDefault(predicate: v => v.Id.Equals(Id), include: include);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}
