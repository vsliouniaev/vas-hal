using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using VAS.Hal.Server.JsonFormatters;

namespace VAS.Hal.Server
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new XmlMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new JQueryMvcFormUrlEncodedFormatter());
            
            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatterWithFullUri());
            
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
