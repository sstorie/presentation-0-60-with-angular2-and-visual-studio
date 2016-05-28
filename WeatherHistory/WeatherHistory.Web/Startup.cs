using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;

namespace WeatherHistory.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Map("/api", api =>
            {
                var config = new HttpConfiguration();

                config.MapHttpAttributeRoutes();

                // Change the API serialization so it does camelCase for
                //  all properties
                //
                var jsonFormatter = config.Formatters.JsonFormatter;
                var settings = jsonFormatter.SerializerSettings;
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                config.EnableSwagger(c =>
                {
                    // Since we mapped the API, we also need to tell Swashbuckle about that
                    //
                    c.RootUrl(req => SwaggerDocsConfig.DefaultRootUrlResolver(req) + "/api");

                    // Just add a little meta-data to the API
                    //
                    c.SingleApiVersion("v1", "Weather History API");

                    // Enable the descriptions in by including all the XML comments
                    //
                    c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\WeatherHistory.Web.XML");
                })
                .EnableSwaggerUi();

                api.UseWebApi(config);
            });

            // Add Nancy to the OWIN pipeline at the end so it handles anything
            //  that WebAPI doesn't
            //
            appBuilder.UseNancy();
        }
    }
}