using Arch.EntityFrameworkCore.UnitOfWork;
using Business.Interface;
using DataAccess.Context;
using Models.Business;
using Models.Filters;
using Models.Infrastructure;
using Moq;

namespace Unit.Test
{
    public class CourseTest
    {
        private readonly ICourseService _courseService;
        private readonly Mock<IUnitOfWork<DBContext>> _unitOfWorkMock;

        public CourseTest()
        {
            var fixture = new TestFixture();

            _courseService = fixture.courseService;
            _unitOfWorkMock = fixture.unitOfWorkMock;
        }

        #region CRUD

        [Fact]
        public void Course_Create_Success()
        {
            //Arrange
            var course = new Course
            {
                Id = 2,
                Name = "Course Test Insert"
            };

            //Act
            var result = _courseService.Create<Course>(course, "Unit Test User");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Course>(course);
            Assert.Equal(2, result.Id);
            Assert.Equal("Course Test Insert", result.Name);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public void Courset_Get_Success(int Id)
        {
            //Act
            var result = _courseService.GetById<Course>(Id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.IsType<Course>(result);
        }

        [Theory]
        [InlineData(6)]
        public void Course_Get_Null(int Id)
        {
            //Act
            var result = _courseService.GetById<Course>(Id);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Course_Search_Success()
        {
            //Arrange
            var filter = new CourseFilter()
            {
                Name = "Course Test"
            };

            //Act
            var result = _courseService.Search<Course>(filter);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Items.Any());
            Assert.Equal(1, result.Items?.FirstOrDefault()?.Id);
            Assert.IsType<List<Course>>(result.Items);
            Assert.IsType<SearchResponse<Course>>(result);
        }

        [Fact]
        public void Course_Search_Null()
        {
            //Arrange
            var filter = new CourseFilter()
            {
                Name = "Course Test Null"
            };

            //Act
            var result = _courseService.Search<Course>(filter);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.Items.Any());
            Assert.IsType<List<Course>>(result.Items);
            Assert.IsType<SearchResponse<Course>>(result);
        }

        [Fact]
        public void Course_Update_Success()
        {
            var course = new Course
            {
                Id = 1,
                Name = "Course Test Updated"
            };

            var result = _courseService.Update<Course>(course, "Unit Test User");

            Assert.NotNull(result);
            Assert.IsType<Course>(result);
            Assert.Equal("Course Test Updated", result.Name);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(false), Times.Once);
        }

        #endregion

    }
}
