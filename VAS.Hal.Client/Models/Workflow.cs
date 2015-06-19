using System;
using HalKit.Json;
using HalKit.Models.Response;
using Newtonsoft.Json;

namespace VAS.Hal.Client.Models
{
    internal class Workflow : Resource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("workflowType")]
        public string WorkflowType { get; set; }

        [JsonProperty("state")]
        public string State { get; private set; }

        [JsonProperty("createdUtc")]
        public DateTime? CreatedUtc { get; private set; }

        [JsonProperty("completedUtc")]
        public DateTime? CompletedUtc { get; set; }

        [Rel("taskactivity")]
        public Link TaskActivityLink { get; set; }

        [Rel("taskactivity-query")]
        public Link TaskActivityQueryLink { get; set; }

        [Rel("taskfield-query")]
        public Link TaskFieldQueryLink { get; set; }
    }
}
