using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using Business.Services;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Models.Business;
using Models.Enums;
using Moq;
using Moq.AutoMock;
using System.Net.Sockets;

namespace Unit.Test
{
    public class TestFixture
    {
        public ICourseService courseService;
        public IExtensionProjectService extensionProjectService;
        public Mock<IUnitOfWork<DBContext>> unitOfWorkMock;
        public readonly IMapper mapper;

        public TestFixture()
        {
            var context = new Mock<DBContext>();
            var dbFacade = new Mock<DatabaseFacade>(context.Object);

            var mockMapper = new MapperConfiguration(cfg =>
            {
            });

            mapper = mockMapper.CreateMapper();

            AutoMocker mocker = new AutoMocker();
            unitOfWorkMock = mocker.GetMock<IUnitOfWork<DBContext>>();

            MockCourse(context, dbFacade, mocker);
            MockExtensionProject(context, dbFacade, mocker);

        }

        public void MockCourse(Mock<DBContext> context, Mock<DatabaseFacade> dbFacade, AutoMocker mocker)
        {
            var course = new Course
            {
                Id = 1,
                Name = "Course Test",
                CreatedAt = DateTime.Now,
                CreatedBy = "Unit Test User",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Unit Test User"
            };

            List<Course> entitybases = new List<Course>() { course };

            var dbSetMock = new Mock<DbSet<Course>>();

            dbSetMock.As<IQueryable<Course>>().Setup(x => x.Provider).Returns(entitybases.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Course>>().Setup(x => x.Expression).Returns(entitybases.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Course>>().Setup(x => x.ElementType).Returns(entitybases.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Course>>().Setup(x => x.GetEnumerator()).Returns(entitybases.AsQueryable().GetEnumerator());

            context.Setup(x => x.Set<Course>()).Returns(dbSetMock.Object);

            var repository = new Repository<Course>(context.Object);

            var dbContextTransaction = new Mock<IDbContextTransaction>();

            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.GetRepository<Course>(false)).Returns(repository);
            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.DbContext.Database).Returns(dbFacade.Object);
            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.DbContext.Database.BeginTransaction()).Returns(dbContextTransaction.Object);
            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.DbContext.Set<Course>()).Returns(dbSetMock.Object);

            courseService = new CourseService(unitOfWorkMock.Object, mapper);
        }

        public void MockExtensionProject(Mock<DBContext> context, Mock<DatabaseFacade> dbFacade, AutoMocker mocker)
        {
            var extensionProject = new ExtensionProject
            {
                Id = 1, 
                ResponsibleUserId = 1,
                Name = "Extension Project Test",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Description = "Extension Project Test",
            };

            List<ExtensionProject> entitybases = new List<ExtensionProject>() { extensionProject };

            var dbSetMockExtensionProject = new Mock<DbSet<ExtensionProject>>();

            dbSetMockExtensionProject.As<IQueryable<ExtensionProject>>().Setup(x => x.Provider).Returns(entitybases.AsQueryable().Provider);
            dbSetMockExtensionProject.As<IQueryable<ExtensionProject>>().Setup(x => x.Expression).Returns(entitybases.AsQueryable().Expression);
            dbSetMockExtensionProject.As<IQueryable<ExtensionProject>>().Setup(x => x.ElementType).Returns(entitybases.AsQueryable().ElementType);
            dbSetMockExtensionProject.As<IQueryable<ExtensionProject>>().Setup(x => x.GetEnumerator()).Returns(entitybases.AsQueryable().GetEnumerator());

            context.Setup(x => x.Set<ExtensionProject>()).Returns(dbSetMockExtensionProject.Object);

            var repositoryExtensionProject = new Repository<ExtensionProject>(context.Object);

            var dbContextTransaction = new Mock<IDbContextTransaction>();

            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.GetRepository<ExtensionProject>(false)).Returns(repositoryExtensionProject);
            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.DbContext.Database).Returns(dbFacade.Object);
            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.DbContext.Database.BeginTransaction()).Returns(dbContextTransaction.Object);
            mocker.GetMock<IUnitOfWork<DBContext>>().Setup(uow => uow.DbContext.Set<ExtensionProject>()).Returns(dbSetMockExtensionProject.Object);

            extensionProjectService = new ExtensionProjectService(unitOfWorkMock.Object, mapper);
        }
    }
}
