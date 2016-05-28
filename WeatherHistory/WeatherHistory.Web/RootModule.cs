using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace WeatherHistory.Web
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}