using MicroS_Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;
using weerp.api.Queries;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;

namespace weerp.api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<ProductDto> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("products")]
        Task<PagedResult<ProductDto>> BrowseAsync([Query] BrowseProducts query);
    }
}
