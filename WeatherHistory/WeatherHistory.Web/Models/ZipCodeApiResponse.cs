using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherHistory.Web.Models
{
    internal class ZipCodeApiResponse
    {
        public string Zipcode { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}