using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherHistory.Web.Models
{
    /// <summary>
    /// An object that represents past temperature data for a Zipcode
    /// </summary>
    public class ZipcodeWeather
    {
        /// <summary>
        /// The zipcode requested
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// The City that corresponds to the zip code
        /// </summary>
        public string City  { get; set; }

        /// <summary>
        /// The state where the city is
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The GPS latitude for the zip code
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// The GPS longitude for the zip code
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// A list of historical temperatures
        /// </summary>
        public List<HistoricalTemperature> HistoricalTemperatures { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        public ZipcodeWeather()
        {
            HistoricalTemperatures = new List<HistoricalTemperature>();
        }
    }

    /// <summary>
    /// A single historical temperature
    /// </summary>
    public class HistoricalTemperature
    {
        /// <summary>
        /// The date of the temperature
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The low temperature for the day (in F)
        /// </summary>
        public float Low { get; set; }

        /// <summary>
        /// The high temperature for the day (in F)
        /// </summary>
        public float High { get; set; }
    }
}