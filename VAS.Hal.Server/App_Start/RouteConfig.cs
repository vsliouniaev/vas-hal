using System.Web.Http;
using System.Web.Routing;

namespace VAS.Hal.Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes
                .MapHttpRoute(
                    "GetResource",
                    "api/{controller}/{id}",
                    new { action = "Get" },
                    new { httpMethod = new HttpMethodConstraint("Get") });

            routes
                .MapHttpRoute(
                    "GetResources",
                    "api/{controller}",
                    new { action = "Get" },
                    new { httpMethod = new HttpMethodConstraint("Get") });

            routes
                .MapHttpRoute(
                    "AddResource",
                    "api/{controller}",
                    new { action = "Add" },
                    new { httpMethod = new HttpMethodConstraint("Post") });

            routes
                .MapHttpRoute(
                    "AddResourceWithIdentifier",
                    "api/{controller}/{id}",
                    new { action = "Add" },
                    new { httpMethod = new HttpMethodConstraint("Post") });

            routes
                .MapHttpRoute(
                    "EditResource",
                    "api/{controller}/{id}",
                    new { action = "Edit" },
                    new { httpMethod = new HttpMethodConstraint("Put") });

            routes
                .MapHttpRoute(
                    "DeleteResource",
                    "api/{controller}/{id}",
                    new { action = "Delete" },
                    new { httpMethod = new HttpMethodConstraint("Delete") });

            routes
                .MapHttpRoute(
                    "GetDefault",
                    "api",
                    new { action = "Get", controller = "ApiVersion" },
                    new { httpMethod = new HttpMethodConstraint("Get") });
        }
    }
}
