using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Filters;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ReportFilter reporteFilter)
        {
            return Execute(() => _reportService.Search<ReportResponse>(reporteFilter), 200, true);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReportPost coursePost)
        {
            return ExecuteCreate(() => _reportService.Create<ReportResponse>(coursePost, ""));
        }
    }
}
