using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTracing;
using System;
using System.Threading.Tasks;
using weerp.api.Framework;
using weerp.api.Messages.Commands.Products;
using weerp.api.Queries;
using weerp.api.Services;
using weerp.domain.Products.Messages.Commands;

namespace weerp.api.Controllers
{
    [AdminAuth]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;
        private readonly ILogger<CreateProduct> _logger;

        public ProductsController(IBusPublisher busPublisher, ITracer tracer,
            IProductsService productsService,ILogger<CreateProduct>logger) : base(busPublisher, tracer)
        {
            _productsService = productsService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseProducts query)
            => Collection(await _productsService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _productsService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateProduct command)
            => await SendAsync(command.BindId(c => c.Id,_logger),  resourceId: command.Id, resource: "products");

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProduct command)
            => await SendAsync(command.Bind(c => c.Id, id),resourceId: command.Id, resource: "products");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteProduct(id));
    }
}
