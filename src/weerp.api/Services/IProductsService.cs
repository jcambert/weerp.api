using MicroS_Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;
using weerp.api.Models.Products;
using weerp.api.Queries;

namespace weerp.api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<Product> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("products")]
        Task<PagedResult<Product>> BrowseAsync([Query] BrowseProducts query);
    }
}
