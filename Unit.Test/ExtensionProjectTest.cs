using Arch.EntityFrameworkCore.UnitOfWork;
using Business.Interface;
using DataAccess.Context;
using Models.Business;
using Models.Filters;
using Models.Infrastructure;
using Moq;

namespace Unit.Test
{
    public class ExtensionProjectTest
    {
        private readonly IExtensionProjectService _extensionProjectService;
        private readonly Mock<IUnitOfWork<DBContext>> _unitOfWorkMock;

        public ExtensionProjectTest()
        {
            var fixture = new TestFixture();

            _extensionProjectService = fixture.extensionProjectService;
            _unitOfWorkMock = fixture.unitOfWorkMock;
        }

        #region CRUD

        [Fact]
        public void ExtensionProject_Create_Success()
        {
            //Arrange
            var extensionProject = new ExtensionProject
            {
                Id = 2,
                Name = "ExtensionProject Test Insert"
            };

            //Act
            var result = _extensionProjectService.Create<ExtensionProject>(extensionProject, "Unit Test User");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ExtensionProject>(extensionProject);
            Assert.Equal(2, result.Id);
            Assert.Equal("ExtensionProject Test Insert", result.Name);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public void ExtensionProject_Get_Success(int Id)
        {
            var result = _extensionProjectService.GetById<ExtensionProject>(Id);

            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.IsType<ExtensionProject>(result);
        }

        [Theory]
        [InlineData(0)]
        public void ExtensionProject_Get_Null(int Id)
        {
            var result = _extensionProjectService.GetById<ExtensionProject>(Id);

            Assert.Null(result);
        }

        [Fact]
        public void ExtensionProject_Search_Success()
        {
            var filter = new ExtensionProjectFilter()
            {
                Name = "Extension Project Test"
            };

            var result = _extensionProjectService.Search<ExtensionProject>(filter);

            Assert.NotNull(result);
            Assert.True(result.Items.Any());
            Assert.Equal(1, result.Items?.FirstOrDefault()?.Id);
            Assert.IsType<List<ExtensionProject>>(result.Items);
            Assert.IsType<SearchResponse<ExtensionProject>>(result);
        }

        [Fact]
        public void ExtensionProject_Search_Null()
        {
            //Arrange
            var filter = new ExtensionProjectFilter()
            {
                Name = "Extension"
            };

            //Act
            var result = _extensionProjectService.Search<ExtensionProject>(filter);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.Items.Any());
            Assert.IsType<List<ExtensionProject>>(result.Items);
            Assert.IsType<SearchResponse<ExtensionProject>>(result);
        }

        [Fact]
        public void ExtensionProject_Update_Success()
        {
            var extensionProject = new ExtensionProject()
            {
                Id = 1,
                ResponsibleUserId = 1,
                Name = "Extension Project Updated",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Description = "Extension Project Test"
            };

            var result = _extensionProjectService.Update<ExtensionProject>(extensionProject, "Unit Test User");

            Assert.NotNull(result);
            Assert.IsType<ExtensionProject>(result);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public void ExtensionProject_Delete_Success(int Id)
        {
            _extensionProjectService.Delete(Id);

            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }
        #endregion

    }
}
