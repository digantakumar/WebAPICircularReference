using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MvcApplication2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureWebApi(GlobalConfiguration.Configuration);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;

            //Removing the JSON or XML Formatter
            //http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
            // Remove the JSON formatter
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            // or
            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Handling Circular Object References
            //http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization

            //To avoid 500 error of circular reference. NOT WORKING
            //http://stackoverflow.com/questions/10897523/asp-net-web-api-showing-correctly-in-vs-but-giving-http500/11387431#11387431
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            //Indenting
            //http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
            json.SerializerSettings.Formatting = Formatting.Indented;
            //Camel Casing
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //Date : Use Microsoft date formater 
            //http://msdn.microsoft.com/en-us/library/bb299886.aspx
            json.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
        }
    }
}