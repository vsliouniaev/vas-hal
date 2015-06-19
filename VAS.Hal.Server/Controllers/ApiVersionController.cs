using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VAS.Hal.Server.Models;
using VAS.Hal.Server.Models.Utility;
using Page = VAS.Hal.Server.Models.Page;

namespace VAS.Hal.Server.Controllers
{
    public class ApiVersionController : ApiController
    {
        private static readonly IEnumerable<string> SupportedVersions = new[] { "1" };

        public HttpResponseMessage Get([FromUri] string id)
        {

            var versionNumber = SupportedVersions.FirstOrDefault(v => v == id);
            if (versionNumber == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(new ApiVersion(versionNumber));
        }

        public PagedList<ApiVersion> Get([FromUri] Page page)
        {
            return
                new Pager<ApiVersion>(
                    () => SupportedVersions.Select(v => new ApiVersion(v)),
                    () => SupportedVersions.Count(),
                    "~/api/apiversion")
                    .GetPage(page);
        }
    }
}