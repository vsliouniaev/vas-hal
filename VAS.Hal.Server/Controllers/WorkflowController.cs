using System;
using System.Net.Http;
using System.Web.Http;
using VAS.Hal.Server.Models;

namespace VAS.Hal.Server.Controllers
{
    public class WorkflowController : ApiController
    {
        public HttpResponseMessage Get([FromUri] string id)
        {
//            var workflow = _reader.Find(id);
//            if (workflow == null)
//            {
//                _log.WarnFormat("Failed to find workflow:{0}", id);
//                return Request.CreateResponse(HttpStatusCode.NotFound);
//            }
            return Request.CreateResponse(ConstructResource());
        }

        private static Workflow ConstructResource()
        {
            return new Workflow("123", "Some-workflow-name", "Some-workflow-type", "Running", DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}