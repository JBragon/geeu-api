using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.HttpInterfaces;
using Business.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Business;
using Models.Filters;
using Models.Infrastructure;
using Models.Mapper.Request;
using Models.Mapper.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class UserService : IUserService
    {
        protected readonly IMapper _mapper;
        private readonly IUFOPHttpService _ufopHttpService;
        private readonly IConfiguration _configuration;
        private readonly ICourseService _courseService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUFOPHttpService ufopHttpService, IConfiguration configuration, ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ufopHttpService = ufopHttpService;
            _configuration = configuration;
            _courseService = courseService;
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

        public virtual User Create(User entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            Repository.Insert(entity);
            _unitOfWork.SaveChanges();

            return entity;
        }

        public virtual User GetById(int Id)
        {
            var outputModel = GetById(Id, null);

            return outputModel;
        }

        public virtual User Update(User entity)
        {

            entity.UpdatedAt = DateTime.Now;

            Repository.Update(entity);
            _unitOfWork.SaveChanges();

            return entity;

        }

        public async Task<LoginResponse> Login(LoginPost request)
        {

            string tokenBasic = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_configuration.GetSection("UFOPAuthorizeObject:Username").Value}:{_configuration.GetSection("UFOPAuthorizeObject:Password").Value}"));

            var response = await _ufopHttpService.Login(request, tokenBasic);

            User userRegistered = Repository.GetFirstOrDefault(predicate: v => v.Email.Equals(response.email));

            if (userRegistered is null && response.primeironome is not null)
            {
                User user = new User
                {
                    UserName = response.primeironome,
                    NormalizedEmail = $"{response.primeironome} {response.ultimonome}",
                    Email = response.email
                };

                Create(user);

                var course = _courseService.Search<Course>(new CourseFilter
                {
                    Name = response.grupo
                });

                if (course.Items.Any())
                {
                    user.Course_Users = new List<Course_User>
                    {
                        new Course_User
                        {
                            CourseId = course.Items.FirstOrDefault().Id,
                            UserId = user.Id
                        }
                    };

                    Update(user);
                }

            }

            var token = BuildToken(response);

            return token;
        }

        private LoginResponse BuildToken(UFOPLoginResponse userInfo)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new LoginResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

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


        protected virtual User GetById(int Id, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null)
        {
            var entity = Repository.GetFirstOrDefault(predicate: v => v.Id.Equals(Id), include: include);

            return entity;
        }
    }
}
