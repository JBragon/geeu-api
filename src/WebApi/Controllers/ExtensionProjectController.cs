using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Filters;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtensionProjectController : BaseController
    {
        private readonly IExtensionProjectService _extensionProjectService;

        public ExtensionProjectController(IExtensionProjectService extensionProjectService)
        {
            _extensionProjectService = extensionProjectService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ExtensionProjectFilter extensionProjectFilter)
        {
            return Execute(() => _extensionProjectService.Search<ExtensionProjectResponse>(extensionProjectFilter), 200, true);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _extensionProjectService.GetById<ExtensionProjectResponse>(id), 200, true);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExtensionProjectPost extensionProjectPost)
        {
            return ExecuteCreate(() => _extensionProjectService.Create<ExtensionProjectResponse>(extensionProjectPost, ""));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ExtensionProjectPut extensionProjectPut)
        {
            return ExecuteCreate(() => _extensionProjectService.Update<ExtensionProjectResponse>(extensionProjectPut, ""));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Execute(() => _extensionProjectService.Delete(id));
        }
    }
}
