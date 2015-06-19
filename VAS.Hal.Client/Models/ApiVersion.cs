using HalKit.Json;
using HalKit.Models.Response;
using Newtonsoft.Json;

namespace VAS.Hal.Client.Models
{
    public class ApiVersion : Resource
    {
        [JsonProperty("versionNumber")]
        public string VersionNumber { get; set; }

        [Rel("workflow")]
        public Link WorkflowLink { get; set; }
    }
}
