using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WeatherHistory.Web.Api
{
    [RoutePrefix("temperatures")]
    public class TemperaturesController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            var response = DateTime.Now;

            return Ok(response);
        }
    }
}