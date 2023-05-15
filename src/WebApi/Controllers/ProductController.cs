using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Filters;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductFilter productFilter)
        {
            return Execute(() => _productService.Search<ProductResponse>(productFilter), 200, true);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _productService.GetById<ProductResponse>(id), 200, true);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductPost productPost)
        {
            return ExecuteCreate(() => _productService.InsertAndClassificateProduct(productPost));
        }
    }
}
