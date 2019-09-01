﻿using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Threading.Tasks;
using weerp.api.Framework;
using weerp.api.Messages.Commands.Products;
using weerp.api.Queries;
using weerp.api.Services;

namespace weerp.api.Controllers
{
    [AdminAuth]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IBusPublisher busPublisher, ITracer tracer,
            IProductsService productsService) : base(busPublisher, tracer)
        {
            _productsService = productsService;
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
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "products");

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProduct command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "products");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteProduct(id));
    }
}
