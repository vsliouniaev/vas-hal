using HalKit.Models.Response;
using Newtonsoft.Json;

namespace VAS.Hal.Client.Models
{
    public abstract class PagedList : Resource
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        
        [JsonProperty("knownPagesAvailable")]
        public int KnownPagesAvailable { get; set; }

        [JsonProperty("totalItemsCount")]
        public int TotalItemsCount { get; set; }
    }
}
