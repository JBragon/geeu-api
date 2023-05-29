using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Filters;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CourseFilter courseFilter)
        {
            return Execute(() => _courseService.Search<CourseResponse>(courseFilter), 200, true);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _courseService.GetById<CourseResponse>(id), 200, true);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CoursePost coursePost)
        {
            return ExecuteCreate(() => _courseService.Create<CourseResponse>(coursePost));
        }
    }
}
