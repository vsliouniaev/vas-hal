using System.Collections.Generic;
using HalKit.Json;
using HalKit.Models.Response;

namespace VAS.Hal.Client.Models
{
    public class Api : PagedList
    {
        [Embedded("apiversion")]
        public IList<ApiVersion> ApiVersion { get; set; }

        [Rel("apiversion")]
        public Link ApiVersionLink { get; set; }
    }
}
