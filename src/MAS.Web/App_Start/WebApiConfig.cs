using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace MAS.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Remove XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure JSON camel case formating
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
