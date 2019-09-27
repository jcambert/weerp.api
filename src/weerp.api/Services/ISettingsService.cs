using MicroS_Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;
using weerp.api.Models.Settings;
using weerp.api.Queries;

namespace weerp.api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ISettingsService
    {
        [AllowAnyStatusCode]
        [Get("settings/{id}")]
        Task<Setting> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("settings")]
        Task<PagedResult<Setting>> BrowseAsync([Query] BrowseSettings query);
    }
}
