using BookATableBot.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookATableBot
{
  public static class WebApiConfig
  {
    public static IntentsList IntentHandlers { get; private set; }
    public static void Register(HttpConfiguration config)
    {
      IntentHandlers = new IntentsList
      {
        {
          "BookATableIntent", (mo)=>Handlers.BookATableIntent.Process(mo)
        },
        {
          "WelcomeIntent", (mo)=>Handlers.WelcomeIntent.Process(mo)
        }
      };
      // Json settings
      config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
      config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
      JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Formatting = Newtonsoft.Json.Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore,
      };

      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
      config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
    }
  }
}
