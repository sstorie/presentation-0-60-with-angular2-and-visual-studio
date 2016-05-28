using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ForecastIO;
using Newtonsoft.Json.Linq;
using RestSharp;
using WeatherHistory.Web.Models;

namespace WeatherHistory.Web.Api
{
    // We derive our API contoller from the base class provided by WebAPI, but
    //  we also specify the route prefix at the controller level
    //
    [RoutePrefix("temperatures")]
    public class TemperaturesController : ApiController
    {
        /// <summary>
        /// Get a collection of the temperatures from previous years
        /// </summary>
        /// <remarks>
        /// This call will retrieve the temperature for the current date and
        /// time for the number of previous years requested.
        /// </remarks>
        /// <param name="zipCode">The zip code to use</param>
        /// <param name="years">The number of years to return</param>
        /// <returns></returns>
        //
        // Now we can use the WebAPI conventions to automatically mark this as 
        //  a GET endpoint, and indicate that it does not add anything to the
        //  route
        //
        [Route("")]
        [ResponseType(typeof(ZipcodeWeather))]
        public IHttpActionResult Get(string zipCode, int? years = 10)
        {
            // Now we can make our first API call to map the zip code
            //  to the geo coordinates we need
            //
            var zipCodeResponse = RequestGeoFromZipcode(zipCode);

            // Let's make sure the zip code was mapped properly before proceeding
            //
            if (zipCodeResponse == null)
            {
                return BadRequest("The zip code could not be mapped to a latitude and longitude");
            }

            var zipcodeWeather = new ZipcodeWeather
            {
                City = zipCodeResponse.City,
                State = zipCodeResponse.State,
                Latitude = zipCodeResponse.Latitude,
                Longitude = zipCodeResponse.Longitude
            };

            // Grab the current date so we can create offsets from it
            //
            var startDate = DateTime.Now;

            // Now loop according to 'years' and use the index each time to make a request back
            //  in time
            //
            foreach (var offset in Enumerable.Range(0, (int)years))
            {
                // Calculate the date for this iteration
                //
                var pastDate = startDate.AddYears(-offset);

                // Make the actual forecast.io call
                //
                var request = new ForecastIORequest(ConfigurationManager.AppSettings["forecast-io-key"], zipCodeResponse.Latitude, zipCodeResponse.Longitude, pastDate, Unit.us);
                var response = request.Get();

                // Create the temp object we need to return and add it to the list
                //
                zipcodeWeather.HistoricalTemperatures.Add(new HistoricalTemperature
                {
                    Date = pastDate,
                    High = response.daily.data[0].temperatureMax,
                    Low = response.daily.data[0].temperatureMin
                });
            }

            // Use the WebAPI base method to return a 200-response with the list as
            //  the payload
            //
            return Ok(zipcodeWeather);
        }

        /// <summary>
        /// Map a zip code string into a response that contains the latitude, 
        /// longitude & city name.
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns>A valid object if the zip code could be mapped, otherwise null in any error condition.</returns>
        private ZipCodeApiResponse RequestGeoFromZipcode(string zipcode)
        {
            // Create a RestSharp client we can use to make the API call
            //
            var client = new RestClient("https://www.zipcodeapi.com");

            // Now build up a request that matches what this API is expecting. We include
            //  out authentication token and the zipcode right in the URI, and that's simple
            //  to do with RestSharp's url segments
            //
            var request = new RestRequest("/rest/{apiKey}/info.json/{zipcode}/degrees", Method.GET);
            request.AddUrlSegment("apiKey", ConfigurationManager.AppSettings["zip-code-api-key"]);
            request.AddUrlSegment("zipcode", zipcode);

            // Now any HTTP call will be asynchronous, but this is trivial to handle with
            //  the async/await functionality available in .NET
            //
            var response = client.Execute(request);

            // Let's make sure the request is valid before attempting to decode anything
            //
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            // Finally, we need to "decode" the JSON data returned so we can load it
            //  into our internal object.
            //
            var content = JObject.Parse(response.Content);

            // Just populate a new object using the key's that existed in the JSON
            //  data returned
            //
            var zipCodeResponse = new ZipCodeApiResponse
            {
                Zipcode = Convert.ToString(content["zip_code"]),
                Latitude = Convert.ToSingle(content["lat"]),
                Longitude = Convert.ToSingle(content["lng"]),
                City = Convert.ToString(content["city"]),
                State = Convert.ToString(content["state"])
            };

            return zipCodeResponse;
        }
    }
}