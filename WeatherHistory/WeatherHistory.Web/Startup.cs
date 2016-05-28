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

                config.EnableSwagger(c =>
                {
                    c.RootUrl(req => SwaggerDocsConfig.DefaultRootUrlResolver(req) + "/api");
                    c.SingleApiVersion("v1", "Weather History API");
                })
                .EnableSwaggerUi();

                api.UseWebApi(config);
            });
        }
    }
}